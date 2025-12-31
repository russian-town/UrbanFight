using Code.Gameplay.Windows;
using UnityEngine;

namespace Code.Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        void Load();
        GameObject GetWindowPrefab(WindowId id);
    }
}
