using Code.Infrastructure.Services.Assets;
using Code.Infrastructure.Services.StaticData;
using Code.Infrastructure.States.Factories;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings() => BindInfrastructureServices();

        private void BindInfrastructureServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();
        }

        public void Initialize() => Container.Resolve<IStaticDataService>().Load();
    }
}
