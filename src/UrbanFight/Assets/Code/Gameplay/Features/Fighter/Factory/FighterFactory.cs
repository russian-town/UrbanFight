using Code.Common.Entity;
using Code.Gameplay.Features.Fighter.Config;
using Code.Infrastructure.Services.Identifiers;
using Code.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Factory
{
    public class FighterFactory : IFighterFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticData;

        public FighterFactory(IIdentifierService identifiers, IStaticDataService staticData)
        {
            _identifiers = identifiers;
            _staticData = staticData;
        }

        public GameEntity CreateFighter(Transform socket)
        {
            FighterConfig config = _staticData.GetFighterConfigByTypeId(FighterTypeId.Ganz);
            
            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .AddWorldPosition(socket.position)
                    .AddViewPrefab(config.EntityTemplate);
        }
    }
}
