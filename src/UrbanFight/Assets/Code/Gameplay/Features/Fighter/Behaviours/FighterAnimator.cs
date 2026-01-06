using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Behaviours
{
    public class FighterAnimator : MonoBehaviour
    {
        private static readonly int HitHash = Animator.StringToHash("Hit");
        private static readonly int WalkForwardHash = Animator.StringToHash("Walk_F");
        private static readonly int WalkBackwardHash = Animator.StringToHash("Walk_B");
        private static readonly int BaseAttackHash = Animator.StringToHash("Base_Attack");
        private static readonly int GetUpHash = Animator.StringToHash("GetUp_A");
        private static readonly int KnockHash = Animator.StringToHash("Knock_A");
        private static readonly int QuickstepHash = Animator.StringToHash("Quickstep_B");
        private static readonly int CounterattackHash = Animator.StringToHash("Counterattack");

        public Animator Animator;

        public void PlayDamageTaken() => Animator.SetTrigger(HitHash);

        public void PlayForwardWalking() => Animator.SetBool(WalkForwardHash, true);

        public void PlayBackwardWalking() => Animator.SetBool(WalkBackwardHash, true);

        public void PlayBaseAttack() => Animator.SetTrigger(BaseAttackHash);
        
        public void PlayQuickstep() => Animator.SetTrigger(QuickstepHash);

        public void PlayGetUp() => Animator.SetTrigger(GetUpHash);

        public void PlayKnock() => Animator.SetTrigger(KnockHash);
        
        public void PlayCounterattack() => Animator.SetTrigger(CounterattackHash);

        public void StopWalking()
        {
            Animator.SetBool(WalkForwardHash, false);
            Animator.SetBool(WalkBackwardHash, false);
        }
    }
}
