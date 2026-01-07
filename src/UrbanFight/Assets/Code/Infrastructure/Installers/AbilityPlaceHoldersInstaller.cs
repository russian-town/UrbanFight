using Code.Infrastructure.Services.Level;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class AbilityPlaceHoldersInstaller : MonoBehaviour, IInitializable
    {
        public RectTransform AbilityLeftPlaceHolder;
        public RectTransform AbilityRightPlaceHolder;

        private ILevelDataProvider _levelDataProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider)
        {
            _levelDataProvider = levelDataProvider;
        }

        public void Initialize()
        {
            _levelDataProvider.AbilityLeftPlaceHolder = AbilityLeftPlaceHolder;
            _levelDataProvider.AbilityRightPlaceHolder = AbilityRightPlaceHolder;
        }
    }
}
