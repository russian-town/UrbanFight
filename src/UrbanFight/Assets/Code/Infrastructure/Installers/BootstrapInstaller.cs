using Code.Common.EntityIndices;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Abilities.Factories;
using Code.Gameplay.Features.Abilities.Services;
using Code.Gameplay.Features.Fighter.Factory;
using Code.Gameplay.Windows;
using Code.Infrastructure.Loading;
using Code.Infrastructure.Services.Assets;
using Code.Infrastructure.Services.Identifiers;
using Code.Infrastructure.Services.Level;
using Code.Infrastructure.Services.StaticData;
using Code.Infrastructure.StateMachine.Game;
using Code.Infrastructure.States;
using Code.Infrastructure.States.Factories;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View.Factory;
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
            BindEntityIndices();
            
            BindInfrastructureServices();
            
            BindGameplayServices();
            BindGameplayFactories();

            BindUIServices();
            
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

        private void BindEntityIndices()
        {
            Container.BindInterfacesAndSelfTo<GameEntityIndices>().AsSingle();
        }
        
        private void BindInfrastructureServices()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
            
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
            
            Container.Bind<IIdentifierService>().To<IdentifierService>().AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
            
            Container.Bind<IAbilityUpgradeService>().To<AbilityUpgradeService>().AsSingle();
            Container.Bind<IAbilitySolver>().To<AbilitySolver>().AsSingle();
        }
        
        private void BindGameplayFactories()
        {
            Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
            Container.Bind<IFighterFactory>().To<FighterFactory>().AsSingle();
            Container.Bind<IAbilityFactory>().To<AbilityFactory>().AsSingle();
        }

        private void BindUIServices()
        {
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            Container.Bind<IWindowFactory>().To<WindowFactory>().AsSingle();
        }

        private void BindSystemsFactory() =>
            Container.Bind<ISystemFactory>().To<SystemFactory>().AsSingle();

        public void Initialize() =>
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
    }
}
