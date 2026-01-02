using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Fighter;
using Code.Gameplay.Features.Fighter.Config;
using Code.Gameplay.Windows;
using UnityEngine;

namespace Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void Load();
        GameObject GetWindowPrefab(WindowId id);
        FighterConfig GetFighterConfigByTypeId(FighterTypeId typeId);
        IEnumerable<AbilityConfig> GetAbilityConfigsByFighterTypeId(FighterTypeId typeId);
    }
}
