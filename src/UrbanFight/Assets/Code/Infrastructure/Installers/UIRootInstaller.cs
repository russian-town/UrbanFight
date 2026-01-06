using Code.Gameplay.Windows;
using Code.Infrastructure.Services.Level;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class UIRootInstaller : MonoBehaviour, IInitializable
    {
        public RectTransform UIRoot;

        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider, IWindowFactory windowFactory)
        {
            _levelDataProvider = levelDataProvider;
            windowFactory.SetUIRoot(UIRoot);
        }

        public void Initialize() => _levelDataProvider.UIRoot = UIRoot;
    }
}
