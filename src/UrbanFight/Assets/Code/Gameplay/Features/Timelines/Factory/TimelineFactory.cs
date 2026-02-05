using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Services.Identifiers;

namespace Code.Gameplay.Features.Timelines.Factory
{
    public class TimelineFactory : ITimelineFactory
    {
        private readonly IIdentifierService _identifiers;

        public TimelineFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateTimeline(int producerId)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddProducerId(producerId)
                .AddNormalizedTime(0f)
                .With(x => x.isTimeline = true)
                .With(x => x.isStarted = true)
                ;
        }
    }
}
