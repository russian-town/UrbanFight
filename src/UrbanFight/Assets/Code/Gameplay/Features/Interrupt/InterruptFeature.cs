using Code.Infrastructure.Systems;
using Code.Gameplay.Interrupt.Systems;

namespace Code.Gameplay.Interrupt
{
    public class InterruptFeature : Feature
    {
        public InterruptFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InterruptTurnSystem>());
        }
    }
}
