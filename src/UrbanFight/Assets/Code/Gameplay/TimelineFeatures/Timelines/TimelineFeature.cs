using Code.Gameplay.TimelineFeatures.Timelines.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.TimelineFeatures.Timelines
{
    public class TimelineFeature : Feature
    {
        public TimelineFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<TimelineUpdateSystem>());
            Add(systemFactory.Create<TimelineEventSystem>());
        }
    }
}
