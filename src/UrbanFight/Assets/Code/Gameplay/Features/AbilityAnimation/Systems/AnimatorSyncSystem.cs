using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.AbilityAnimation.Systems
{
    public class AnimatorLayerSyncSystem : IExecuteSystem
    {
        private static readonly int BaseState = Animator.StringToHash("BaseState");
        private static readonly int ActionState = Animator.StringToHash("ActionState");
        private static readonly int ActionWeight = Animator.StringToHash("ActionWeight");
        private static readonly int ReactionState = Animator.StringToHash("ReactionState");
        private static readonly int ReactionWeight = Animator.StringToHash("ReactionWeight");

        private readonly IGroup<GameEntity> _fighters;

        public AnimatorLayerSyncSystem(GameContext game)
        {
            _fighters = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.FighterAnimator));
        }

        public void Execute()
        {
            foreach (GameEntity fighter in _fighters)
            {
                Animator animator = fighter.FighterAnimator.Animator;

                animator.SetInteger(BaseState, (int)fighter.BaseAnimationState);

                animator.SetInteger(ActionState, (int)fighter.ActionAnimationState);
                animator.SetFloat(ActionWeight, fighter.ActionAnimationWeight);

                animator.SetInteger(ReactionState, (int)fighter.ReactionAnimationState);
                animator.SetFloat(ReactionWeight, fighter.ReactionAnimationWeight);
            }
        }
    }
}
