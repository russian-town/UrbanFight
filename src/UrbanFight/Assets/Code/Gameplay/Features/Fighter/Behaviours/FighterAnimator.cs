using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Behaviours
{
    public class FighterAnimator : MonoBehaviour
    {
        private static readonly int StateHash = Animator.StringToHash("State");

        public Animator Animator;

        public void PlayJumpUp(float normalizedTime)
        {
            Animator.speed = 0f;
            Animator.Play("JumpUp", 0, normalizedTime);
        }

        public void PlayMoveForwardAir(float normalizedTime)
        {
            Animator.speed = 0f;
            Animator.Play("MoveForwardAir", 0, normalizedTime);
        }

        public void PlaySlamDown(float normalizedTime)
        {
            Animator.speed = 0f;
            Animator.Play("SlamDown", 0, normalizedTime);
        }

        //public void SetState(BaseAnimationState state) => Animator.SetInteger(StateHash, (int)state);
        public void Play(int taskValue)
        {
            
        }
    }
}
