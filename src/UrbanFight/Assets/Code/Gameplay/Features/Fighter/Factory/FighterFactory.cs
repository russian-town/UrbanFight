using System.Linq;
using Code.Common.Entity;
using Code.Gameplay.Features.Fighter.Config;
using Code.Gameplay.FighterStats;
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
                    .AddWorldRotation(socket.rotation)
                    .AddViewPrefab(config.EntityTemplate)
                    .AddBaseHealth(config.FighterStats.First(x => x.StatTypeId == StatTypeId.BaseHealth).Value)
                    .AddBaseDamage(config.FighterStats.First(x => x.StatTypeId == StatTypeId.BaseDamage).Value)
                    .AddBaseArmor(config.FighterStats.First(x => x.StatTypeId == StatTypeId.BaseArmor).Value)
                ;
        }
    }
}
