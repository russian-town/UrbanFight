using Code.Infrastructure.Services.Level;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class SocketsInstaller : MonoBehaviour, IInitializable
    {
        public Transform RightSocket;
        public Transform LeftSocket;

        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
        }

        public void Initialize()
        {
            _levelDataProvider.RightSocket = RightSocket;
            _levelDataProvider.LeftSocket = LeftSocket;
        }
    }
}
