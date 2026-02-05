using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Timelines.Systems
{
    public class CleanupTimelinesSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _timelines;
        private readonly List<GameEntity> _buffer = new(16);

        public CleanupTimelinesSystem(GameContext game)
        {
            _timelines = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Timeline,
                    GameMatcher.Completed));
        }
        
        public void Cleanup()
        {
            foreach (GameEntity timeline in _timelines.GetEntities(_buffer))
                timeline.isDestructed = true;
        }
    }
}
