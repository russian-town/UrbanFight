using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Fighter;
using Code.Gameplay.Features.Fighter.Config;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using Code.Infrastructure.Services.Assets;
using UnityEngine;

namespace Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _asset;

        private Dictionary<FighterTypeId, FighterConfig> _getEntityByTypeId = new();
        private Dictionary<WindowId, GameObject> _getWindowByTypeId = new();
        private List<AbilityConfig> _allAbilities = new();

        public StaticDataService(IAssetProvider asset) => _asset = asset;

        public void Load()
        {
            LoadFighterConfigs();
            LoadAbilitiesConfigs();
            LoadWindowsStaticData();
        }

        public GameObject GetWindowPrefab(WindowId id)
        {
            if (_getWindowByTypeId.TryGetValue(id, out GameObject prefab))
                return prefab;

            throw new ArgumentException($"Window prefab with id {id} not found.");
        }

        public FighterConfig GetFighterConfigByTypeId(FighterTypeId typeId)
        {
            if (_getEntityByTypeId.TryGetValue(typeId, out FighterConfig config))
                return config;

            throw new ArgumentException($"Fighter config with type id {typeId} not found.");
        }

        public IEnumerable<AbilityConfig> GetAbilityConfigsByFighterTypeId(FighterTypeId typeId) =>
            _allAbilities.Where(x => x.FighterTypeId == typeId);

        private void LoadFighterConfigs()
        {
            _getEntityByTypeId = _asset
                .LoadAll<FighterConfig>("StaticData/Fighter")
                .ToDictionary(x => x.TypeId, x => x);
        }

        private void LoadAbilitiesConfigs()
        {
            _allAbilities = _asset
                .LoadAll<AbilityConfig>("StaticData/Abilities")
                .ToList();
        }

        private void LoadWindowsStaticData()
        {
            _getWindowByTypeId = _asset
                .LoadAll<WindowsConfig>("StaticData/UI/Windows")
                .First()
                .WindowConfigs
                .ToDictionary(x => x.Id, x => x.Prefab);
        }
    }
}
