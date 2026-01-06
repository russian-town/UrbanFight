using System.Collections.Generic;
using Code.Gameplay.Features.Request.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class BaseAbilitySystem : IExecuteSystem
    {
        private readonly IRequestFactory _requestFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _fighters;
        private readonly List<GameEntity> _buffer = new(16);

        public BaseAbilitySystem(GameContext game, IRequestFactory requestFactory)
        {
            _requestFactory = requestFactory;

            _abilities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Ability,
                        GameMatcher.AbilityTypeId,
                        GameMatcher.BaseAttack,
                        GameMatcher.EffectSetups,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.Cooldown
                    )
                    .NoneOf(GameMatcher.Casted));

            _fighters = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Fighter,
                        GameMatcher.FighterAnimator,
                        GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            foreach (GameEntity fighter in _fighters)
            {
                if (ability.ProducerId != fighter.Id)
                    continue;

                _requestFactory.CreateRequest(
                    ability.AbilityTypeId,
                    ability.ProducerId,
                    ability.TargetId);

                fighter.FighterAnimator.PlayBaseAttack();
                ability.ReplaceCooldown(1f);
                ability.isCasted = true;
            }
        }
    }
}
