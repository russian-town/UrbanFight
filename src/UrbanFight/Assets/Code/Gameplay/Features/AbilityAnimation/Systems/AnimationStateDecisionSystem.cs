using Entitas;

namespace Code.Gameplay.Features.AbilityAnimation.Systems
{
    public class AnimationStateDecisionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _fighters;

        public AnimationStateDecisionSystem(GameContext game)
        {
            _fighters = game.GetGroup(GameMatcher.AllOf(GameMatcher.BaseAnimationState));
        }

        public void Execute()
        {
            foreach (GameEntity fighter in _fighters)
            {
                /*float timeline = fighter.CombatTimeline;

                BaseAnimationState state;

                if (fighter.hasAttackIntent)
                    state = BaseAnimationState.Knockback;

                else if (fighter.isKnockback)
                    state = BaseAnimationState.Attack;

                else if (fighter.hasMovementIntent)
                    state = BaseAnimationState.WalkForward;

                else
                    state = BaseAnimationState.Idle;

                if (fighter.BaseAnimationState != state)
                    fighter.ReplaceAnimationState(state);*/
            }
        }
    }
}
