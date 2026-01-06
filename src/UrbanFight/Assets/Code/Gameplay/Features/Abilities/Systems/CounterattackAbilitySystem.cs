using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class CounterattackAbilitySystem : IExecuteSystem
    {
        private readonly IEffectFactory _effectFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _fighters;
        private readonly List<GameEntity> _buffer = new(16);

        public CounterattackAbilitySystem(GameContext game, IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;

            _abilities = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Ability,
                        GameMatcher.AbilityTypeId,
                        GameMatcher.Counterattack,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.EffectSetups,
                        GameMatcher.CooldownUp
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

                foreach (EffectSetup effectSetup in ability.EffectSetups)
                    _effectFactory.CreateEffect(
                        effectSetup,
                        ability.ProducerId,
                        ability.TargetId);
                
                ability.isCasted = true;
            }
        }
    }
}
