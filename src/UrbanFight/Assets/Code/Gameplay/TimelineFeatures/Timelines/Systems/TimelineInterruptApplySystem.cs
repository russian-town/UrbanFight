using Entitas;

namespace Code.Gameplay.TimelineFeatures.Timelines.Systems
{
    public class TimelineInterruptApplySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _requests;
        private readonly IGroup<GameEntity> _timelines;

        public TimelineInterruptApplySystem(GameContext game)
        {
            _requests = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.InterruptRequest,
                        GameMatcher.InterruptTargetId)
                    .NoneOf(GameMatcher.Processed));

            _timelines = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Timeline,
                    GameMatcher.TimelineOwnerId,
                    GameMatcher.ActiveTimeline));
        }

        public void Execute()
        {
            foreach (GameEntity request in _requests)
            {
                request.isProcessed = true;

                int targetId = request.InterruptTargetId;

                foreach (GameEntity timeline in _timelines)
                {
                    if (timeline.TimelineOwnerId != targetId)
                        continue;

                    timeline.isDestructed = true;
                }
            }
        }
    }
}
