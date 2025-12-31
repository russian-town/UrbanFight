using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class SceneInitializationInstaller : MonoInstaller
    {
        public List<MonoBehaviour> Initializers;

        public override void InstallBindings()
        {
            BindInitializers();
        }

        private void BindInitializers()
        {
            foreach (MonoBehaviour initializer in Initializers)
                Container
                    .BindInterfacesTo(initializer.GetType())
                    .FromInstance(initializer)
                    .AsSingle();
        }
    }
}
