using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Combats.Systems
{
    public class TelegraphPhaseSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(32);

        public TelegraphPhaseSystem(GameContext game)
        {
            _abilities = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.Ability,
                        GameMatcher.AbilityExecutionState)
                    .NoneOf(GameMatcher.TelegraphPhase));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
                ability.isTelegraphPhase = true;
        }
    }
}
