using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class BaseAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _fighters;
        private readonly List<GameEntity> _buffer = new(16);

        public BaseAbilitySystem(GameContext game)
        {
            _abilities = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.Ability,
                        GameMatcher.BaseAttack,
                        GameMatcher.AttackTime)
                    .NoneOf(GameMatcher.Casted));

            _fighters = game.GetGroup(
                GameMatcher.AllOf(
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

                ability.AddCooldown(ability.AttackTime);
                ability.AddCooldownLeft(ability.AttackTime);
                
                fighter.FighterAnimator.PlayBaseAttack();
                ability.isCasted = true;
            }
        }
    }
}
