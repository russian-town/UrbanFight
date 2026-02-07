using Code.Gameplay.Features.Abilities;
using Entitas;

namespace Code.Gameplay.TimelineFeatures.Timelines.Systems
{
    public class ReactionTimelineCreateSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _requests;

        public ReactionTimelineCreateSystem(GameContext game)
        {
            _game = game;

            _requests = game.GetGroup(
                GameMatcher
                    .AllOf(GameMatcher.InterruptRequest)
                    .NoneOf(GameMatcher.ReactionCreated));
        }

        public void Execute()
        {
            foreach (GameEntity request in _requests)
            {
                request.isReactionCreated = true;

                GameEntity timeline = _game.CreateEntity();

                timeline.isTimeline = true;
                timeline.isActiveTimeline = true;

                timeline.AddTimelineOwnerId(request.InterruptTargetId);
                timeline.AddParentAbilityId(AbilityTypeId.ReactionStagger);
                timeline.AddTimelineDuration(0.6f);
                timeline.AddTimelineTime(0f);
            }
        }
    }
}
