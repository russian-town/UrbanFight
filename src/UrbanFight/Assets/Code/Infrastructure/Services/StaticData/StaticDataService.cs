using Code.Gameplay.Windows;
using UnityEngine;

namespace Code.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        public void Load() { }
        public GameObject GetWindowPrefab(WindowId id) => null;
    }
}
