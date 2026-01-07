using Code.Gameplay.Features.Lifetime.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Lifetime
{
    public class LifetimeComponents
    {
        [Game] public class HealthBarComponent : IComponent { public HealthBar Value; }
        [Game] public class Dead : IComponent { }
        [Game] public class ProcessingDeath : IComponent { }
    }
}
