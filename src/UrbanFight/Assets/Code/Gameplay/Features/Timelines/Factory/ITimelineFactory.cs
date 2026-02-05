namespace Code.Gameplay.Features.Timelines.Factory
{
    public interface ITimelineFactory
    {
        GameEntity CreateTimeline(int producerId);
    }
}
