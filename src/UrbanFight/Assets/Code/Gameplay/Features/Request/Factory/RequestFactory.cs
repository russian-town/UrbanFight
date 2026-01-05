using Code.Common.Entity;
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

        public GameEntity CreateRequest()
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next());
        }
    }
}
