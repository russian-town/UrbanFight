using Entitas;

namespace Code.Gameplay.Features.AbilityAnimation.Systems
{
    public class TimelineAnimationDecisionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _timelines;

        public TimelineAnimationDecisionSystem(GameContext game)
        {
            _timelines = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Timeline));
        }

        public void Execute()
        {
            foreach (GameEntity timeline in _timelines)
            {
                //float time = timeline.NormilizeTime;

                DecideBase(timeline, 0);
                DecideAction(timeline, 0);
                DecideReaction(timeline);
            }
        }

        private static void DecideBase(GameEntity timeline, float t)
        {
            timeline.ReplaceBaseAnimationState(
                timeline.hasBaseAnimationState
                    ? BaseAnimationState.WalkForward
                    : BaseAnimationState.Idle);
        }
        
        private static void DecideAction(GameEntity e, float t)
        {
            /*if (!e.hasAttackTimeline)
            {
                e.ReplaceActionAnimationState(ActionAnimationState.None);
                e.ReplaceWeight(0f);
                return;
            }

            float localT = 0f;/*NormalizeT(
                t,
                e.AttackTimeline.Start,
                e.AttackTimeline.End);
                #1#

            e.ReplaceActionAnimationState(ActionAnimationState.Attack);
            e.ReplaceWeight(localT > 0 && localT < 1 ? 1f : 0f);*/
        }
        
        private static void DecideReaction(GameEntity e)
        {
            /*if (e.hasKnockbackIntent)
            {
                e.ReplaceReactionAnimationState(ReactionAnimationState.Knockback);
                e.ReplaceWeight(1f);
                return;
            }

            if (e.hasHitReaction)
            {
                e.ReplaceReactionAnimationState(ReactionAnimationState.Hit);
                e.ReplaceWeight(1f);
                return;
            }

            e.ReplaceReactionAnimationState(ReactionAnimationState.None);
            e.ReplaceWeight(0f);*/
        }
    }
}
