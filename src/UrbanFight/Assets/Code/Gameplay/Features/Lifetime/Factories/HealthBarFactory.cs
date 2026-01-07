using Code.Common.Entity;
using Code.Infrastructure.Services.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Lifetime.Factories
{
    public class HealthBarFactory : IHealthBarFactory
    {
        private const string PathToHealthBarPrefab = "Prefabs/UI/HUD/Lifetime/HealthBar";
        
        private readonly IIdentifierService _identifiers;

        public HealthBarFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateHealthBar(int targetId, RectTransform parent)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddParent(parent)
                .AddTargetId(targetId)
                .AddViewPath(PathToHealthBarPrefab);
        }
    }
}
