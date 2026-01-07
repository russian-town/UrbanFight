using Code.Infrastructure.Services.Level;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class HealthBarSocketsInstaller : MonoBehaviour, IInitializable
    {
        public RectTransform LeftHealthBarSocket;
        public RectTransform RightHealthBarSocket;

        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
        }

        public void Initialize()
        {
            _levelDataProvider.LeftHealthBarSocket = LeftHealthBarSocket;
            _levelDataProvider.RightHealthBarSocket = RightHealthBarSocket;
        }
    }
}
