using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Fighter;
using Code.Gameplay.Features.Fighter.Config;
using Code.Gameplay.Windows;
using Code.Infrastructure.Services.Assets;
using UnityEngine;

namespace Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _asset;
        
        private Dictionary<FighterTypeId, FighterConfig> _getEntityByTypeId = new();

        public StaticDataService(IAssetProvider asset)
        {
            _asset = asset;
        }

        public void Load()
        {
            LoadFighterConfigs();
        }

        public GameObject GetWindowPrefab(WindowId id) => null;

        public FighterConfig GetFighterConfigByTypeId(FighterTypeId typeId)
        {
            if (_getEntityByTypeId.TryGetValue(typeId, out FighterConfig config))
                return config;

            throw new ArgumentException($"Fighter config with type id {typeId} not found.");
        }

        private void LoadFighterConfigs()
        {
            _getEntityByTypeId = _asset
                .LoadAll<FighterConfig>("StaticData/Fighter")
                .ToDictionary(x => x.TypeId, x => x);
        }
    }
}
