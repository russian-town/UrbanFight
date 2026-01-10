using Code.Common.Entity;
using Code.Gameplay.Features.Fighter;
using Code.Gameplay.Features.Fighter.Factory;
using Code.Gameplay.Features.Lifetime.Factories;
using Code.Infrastructure.Services.Level;
using Code.Infrastructure.Services.StaticData;
using Code.Infrastructure.StateMachine.Game;
using Code.Infrastructure.States.Abstract;

namespace Code.Infrastructure.States
{
    public class BattleEnterState : IState
    {
        private const string PathToAbilityHolderPrefab = "Prefabs/UI/HUD/Abilities/AbilityPlaceHolder";
        
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IFighterFactory _fighterFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IHealthBarFactory _healthBarFactory;
        private readonly IStaticDataService _staticDataService;

        public BattleEnterState(
            IGameStateMachine gameStateMachine,
            IFighterFactory fighterFactory,
            ILevelDataProvider levelDataProvider,
            IHealthBarFactory healthBarFactory)
        {
            _gameStateMachine = gameStateMachine;
            _fighterFactory = fighterFactory;
            _levelDataProvider = levelDataProvider;
            _healthBarFactory = healthBarFactory;
        }

        public void Enter()
        {
            GameEntity hero = PlaceHero();
            GameEntity enemy = PlaceEnemy();

            CreateAbilityHolders(hero.Id, enemy.Id);
            SetFighterTargets(hero, enemy);
            CreateHealthBars(hero.Id, enemy.Id);

            _gameStateMachine.Enter<BattleLoopState>();
        }

        public void Update() { }

        public void Exit() { }

        private GameEntity PlaceHero() =>
            _fighterFactory.CreateFighter(_levelDataProvider.LeftSocket);

        private GameEntity PlaceEnemy() =>
            _fighterFactory.CreateFighter(_levelDataProvider.RightSocket);

        private void CreateAbilityHolders(int heroId, int enemyId)
        {
            CreateEntity.Empty()
                .AddViewPath(PathToAbilityHolderPrefab)
                .AddParent(_levelDataProvider.AbilityLeftPlaceHolder)
                .AddTargetId(heroId);
            
            CreateEntity.Empty()
                .AddViewPath(PathToAbilityHolderPrefab)
                .AddParent(_levelDataProvider.AbilityRightPlaceHolder)
                .AddTargetId(enemyId);
        }

        private void CreateHealthBars(int heroId, int enemyId)
        {
            _healthBarFactory.CreateHealthBar(heroId, _levelDataProvider.LeftHealthBarSocket);
            _healthBarFactory.CreateHealthBar(enemyId, _levelDataProvider.RightHealthBarSocket);
        }

        private static void SetFighterTargets(GameEntity hero, GameEntity enemy)
        {
            hero.AddTargetId(enemy.Id);
            enemy.AddTargetId(hero.Id);
            hero.isActive = true;
        }
    }
}
