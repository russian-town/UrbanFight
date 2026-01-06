using System.Collections.Generic;
using System.Linq;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Fighter.Config;
using Code.Gameplay.Features.FighterStats;
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
            Dictionary<StatTypeId, float> baseStats = config.FighterStats.ToDictionary(x => x.StatTypeId, x => x.Value); 

            return CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .AddFighterTypeId(config.TypeId)
                    .AddWorldPosition(socket.position)
                    .AddWorldRotation(socket.rotation)
                    .AddViewPrefab(config.EntityTemplate)
                    .AddBaseStats(baseStats)
                    .AddCurrentHealth(baseStats[StatTypeId.BaseHealth])
                    .AddMaxHealth(baseStats[StatTypeId.BaseHealth])
                    .AddBaseArmor(baseStats[StatTypeId.BaseArmor])
                    .AddBaseDamage(baseStats[StatTypeId.BaseDamage])
                    .AddStatModifiers(new Dictionary<StatTypeId, float>())
                    .With(x => x.isFighter = true)
                ;
        }
    }
}
