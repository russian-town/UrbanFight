using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.TimelineFeatures.Timelines.Systems
{
    public class TimelineUpdateSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _timelines;

        public TimelineUpdateSystem(GameContext game, ITimeService time)
        {
            _time = time;

            _timelines = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Timeline,
                    GameMatcher.Duration,
                    GameMatcher.ActiveTimeline));
        }

        public void Execute()
        {
            foreach (GameEntity timeline in _timelines)
            {
                float step = _time.DeltaTime / timeline.Duration;
                timeline.ReplaceTimelineTime(timeline.TimelineTime + step);
            }
        }
    }
}
