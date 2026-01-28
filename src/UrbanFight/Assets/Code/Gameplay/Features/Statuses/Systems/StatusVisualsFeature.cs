using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class StatusVisualsFeature : Feature
    {
        public StatusVisualsFeature(ISystemFactory systems)
        {
            Add(systems.Create<ApplyCounterAttackStatusSystem>());
            Add(systems.Create<ApplyBlockStatusSystem>());
        }
    }
}
