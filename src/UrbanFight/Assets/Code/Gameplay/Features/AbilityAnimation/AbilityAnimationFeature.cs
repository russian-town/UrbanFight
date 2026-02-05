using Code.Gameplay.Features.AbilityAnimation.Jump;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.AbilityAnimation
{
    public class AbilityAnimationFeature : Feature
    {
        public AbilityAnimationFeature(ISystemFactory systems)
        {
            Add(systems.Create<UpdateJumpAnimationSystem>());
        }
    }
}
