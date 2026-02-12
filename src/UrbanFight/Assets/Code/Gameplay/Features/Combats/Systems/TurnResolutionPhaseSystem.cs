using System.Collections.Generic;
using Code.Common.Entity;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Infrastructure.Services.Identifiers;
using Code.Infrastructure.Services.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Combats.Systems
{
    public class TurnResolutionPhaseSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(32);

        public TurnResolutionPhaseSystem(GameContext game)
        {
            _abilities = game.GetGroup(
                GameMatcher.AllOf(GameMatcher.EffectResolutionPhase)
                    .NoneOf(GameMatcher.TurnResolutionPhase));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
                ability.isTurnResolutionPhase = true;
        }
    }
}
