using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Combats.Systems
{
    public class EffectResolutionPhaseSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(32);

        public EffectResolutionPhaseSystem(GameContext game)
        {
            _abilities = game.GetGroup(
                GameMatcher
                    .AllOf(GameMatcher.StatusResolutionPhase)
                    .NoneOf(GameMatcher.EffectResolutionPhase));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
                ability.isEffectResolutionPhase = true;
        }
    }
}
