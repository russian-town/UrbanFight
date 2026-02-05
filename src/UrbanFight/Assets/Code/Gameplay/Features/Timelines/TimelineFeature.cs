using Code.Gameplay.Features.Timelines.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Timelines
{
    public class TimelineFeature : Feature
    {
        public TimelineFeature(ISystemFactory system)
        {
            Add(system.Create<UpdateTimelineSystem>());
            Add(system.Create<CleanupTimelinesSystem>());
        } 
    }
}
