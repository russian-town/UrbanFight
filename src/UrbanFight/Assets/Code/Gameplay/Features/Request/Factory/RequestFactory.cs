using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Infrastructure.Services.Identifiers;

namespace Code.Gameplay.Features.Request.Factory
{
    public class RequestFactory : IRequestFactory
    {
        private readonly IIdentifierService _identifiers;

        public RequestFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateRequest(AbilityTypeId ability, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.isRequest = true)
                .AddParentAbilityId(ability);
        }
    }
}
