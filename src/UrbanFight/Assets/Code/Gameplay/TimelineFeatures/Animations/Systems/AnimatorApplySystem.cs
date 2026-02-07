using Entitas;
using UnityEngine;

namespace Code.Gameplay.TimelineFeatures.Animations.Systems
{
    public class AnimatorApplySystem : IExecuteSystem
    {
        private static readonly int BaseState = Animator.StringToHash("BaseState");
        private static readonly int ActionState = Animator.StringToHash("ActionState");
        private static readonly int ReactionState = Animator.StringToHash("ReactionState");
        
        private readonly IGroup<GameEntity> _fighters;

        public AnimatorApplySystem(GameContext game)
        {
            _fighters = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Id,
                    GameMatcher.FighterAnimator,
                    GameMatcher.BaseAnimationStateId,
                    GameMatcher.ActionAnimationStateId,
                    GameMatcher.ReactionAnimationStateId));
        }

        public void Execute()
        {
            foreach (GameEntity fighter in _fighters)
            {
                Animator animator = fighter.FighterAnimator.Animator;
                
                if (animator == null)
                    continue;

                animator.SetInteger(BaseState, fighter.BaseAnimationStateId);
                animator.SetInteger(ActionState, fighter.ActionAnimationStateId);
                animator.SetInteger(ReactionState, fighter.ReactionAnimationStateId);
            }
        }
    }
}
