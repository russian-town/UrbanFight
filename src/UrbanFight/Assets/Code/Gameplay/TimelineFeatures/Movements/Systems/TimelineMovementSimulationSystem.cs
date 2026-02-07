using Entitas;
using UnityEngine;

namespace Code.Gameplay.TimelineFeatures.Movements.Systems
{
    public class TimelineMovementSimulationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _timelines;
        private readonly IGroup<GameEntity> _fighters;

        public TimelineMovementSimulationSystem(GameContext game)
        {
            _timelines = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Timeline,
                        GameMatcher.ActiveTimeline,
                        GameMatcher.MovementTrack,
                        GameMatcher.TimelineOwnerId,
                        GameMatcher.TimelineTime,
                        GameMatcher.TimelineDuration,
                        GameMatcher.MoveStartTime,
                        GameMatcher.MoveEndTime)
                    .NoneOf(GameMatcher.Destructed));

            _fighters = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition,
                    GameMatcher.StartPosition));
        }

        public void Execute()
        {
            foreach (GameEntity timeline in _timelines)
            {
                GameEntity fighter = FindFighter(timeline.TimelineOwnerId);

                if (fighter == null)
                    continue;

                float normalized = timeline.TimelineTime / timeline.TimelineDuration;
                float start = timeline.MoveStartTime;
                float end = timeline.MoveEndTime;

                if (normalized < start || normalized > end)
                    continue;

                float localT = (normalized - start) / (end - start);

                Vector3 from = fighter.StartPosition;
                Vector3 to = ResolveTargetPosition(timeline);
                Vector3 position = Vector3.Lerp(from, to, localT);

                fighter.ReplaceWorldPosition(position);
            }
        }

        private GameEntity FindFighter(int id)
        {
            foreach (GameEntity fighter in _fighters)
            {
                if (fighter.Id == id)
                    return fighter;
            }

            return null;
        }

        private Vector3 ResolveTargetPosition(GameEntity timeline)
        {
            if (!timeline.hasTimelineTargetId)
                return Vector3.zero;

            foreach (GameEntity fighter in _fighters)
            {
                if (fighter.Id == timeline.TimelineTargetId)
                    return fighter.WorldPosition;
            }

            return Vector3.zero;
        }
    }
}
