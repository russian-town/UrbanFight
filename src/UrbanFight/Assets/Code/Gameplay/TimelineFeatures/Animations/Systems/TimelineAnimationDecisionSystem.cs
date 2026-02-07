using Entitas;

namespace Code.Gameplay.TimelineFeatures.Animations.Systems
{
    public class TimelineAnimationDecisionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _timelines;

        public TimelineAnimationDecisionSystem(GameContext game)
        {
            _game = game;

            _timelines = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.Timeline,
                        GameMatcher.ActiveTimeline,
                        GameMatcher.AnimationTypeId,
                        GameMatcher.AnimationTrack,
                        GameMatcher.AnimationStateId)
                    .NoneOf(GameMatcher.Destructed));
        }

        public void Execute()
        {
            foreach (GameEntity timeline in _timelines)
            {
                GameEntity fighter = _game.GetEntityWithId(timeline.TimelineOwnerId);

                if (fighter == null)
                    continue;

                int animState = timeline.AnimationStateId;

                switch (timeline.AnimationTypeId)
                {
                    case AnimationTypeId.Reaction:
                        fighter.ReplaceReactionAnimationStateId(animState);
                        break;
                    case AnimationTypeId.Action:
                        fighter.ReplaceActionAnimationStateId(animState);
                        break;
                    default:
                        fighter.ReplaceBaseAnimationStateId(animState);
                        break;
                }
            }
        }
    }
}
