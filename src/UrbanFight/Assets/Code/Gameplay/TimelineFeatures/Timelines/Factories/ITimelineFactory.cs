using Code.Gameplay.Features.Abilities.Configs;

namespace Code.Gameplay.TimelineFeatures.Timelines.Factories
{
    public interface ITimelineFactory
    {
        GameEntity CreateTimeline(AbilityConfig config, int producerId, int targetId);
    }
}
