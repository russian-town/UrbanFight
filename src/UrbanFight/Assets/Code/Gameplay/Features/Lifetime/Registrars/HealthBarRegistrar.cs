using Code.Gameplay.Features.Lifetime.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Lifetime.Registrars
{
    public class HealthBarRegistrar : EntityComponentRegistrar
    {
        public HealthBar HealthBar;
        
        public override void RegisterComponents() =>
            Entity.AddHealthBar(HealthBar);

        public override void UnregisterComponents()
        {
            if (Entity.hasHealthBar)
                Entity.RemoveHealthBar();
        }
    }
}
