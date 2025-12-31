using Code.Gameplay.Features.Fighter.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Fighter.Registrars
{
    public class FighterAnimatorRegistrar : EntityComponentRegistrar
    {
        public FighterAnimator FighterAnimator;

        public override void RegisterComponents()
        {
            Entity.AddFighterAnimator(FighterAnimator);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasFighterAnimator)
                Entity.RemoveFighterAnimator();
        }
    }
}
