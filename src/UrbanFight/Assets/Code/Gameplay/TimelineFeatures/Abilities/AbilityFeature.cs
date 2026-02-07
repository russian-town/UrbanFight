using Code.Gameplay.TimelineFeatures.Abilities.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.TimelineFeatures.Abilities
{
    public class AbilityFeature : Feature
    {
        public AbilityFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<AbilityTimelineCreateSystem>());
        }
    }
}
