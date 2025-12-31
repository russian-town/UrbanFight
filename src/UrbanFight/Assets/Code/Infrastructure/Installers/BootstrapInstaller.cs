using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Loading;
using Code.Infrastructure.Services.Assets;
using Code.Infrastructure.Services.StaticData;
using Code.Infrastructure.StateMachine.Game;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Factories;
using Code.Infrastructure.Systems;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class BootstrapInstaller : MonoInstaller, IInitializable, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            BindStateFactory();
            BindGameStates();

            BindContexts();
            
            BindInfrastructureServices();
            BindGameplayServices();
            BindSystemsFactory();
        }

        private void BindStateMachine() =>
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();

        private void BindStateFactory() =>
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();

        private void BindGameStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingBattleState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleEnterState>().AsSingle();
            Container.BindInterfacesAndSelfTo<BattleLoopState>().AsSingle();
        }

        private void BindContexts()
        {
            Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
            Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
        }

        private void BindSystemsFactory() =>
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();

        public void Initialize() =>
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
    }
}
