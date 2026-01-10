using Code.Gameplay.Features.Abilities.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Abilities.Registrars
{
    public class AbilityHolderRegistrar : EntityComponentRegistrar
    {
        public AbilityHolder AbilityHolder;
        
        public override void RegisterComponents() =>
            Entity.AddAbilityHolder(AbilityHolder);

        public override void UnregisterComponents()
        {
            if (Entity.hasAbilityHolder)
                Entity.RemoveAbilityHolder();
        }
    }
}
