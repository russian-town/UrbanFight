using Code.Gameplay.Features.Fighter.Factory;
using Code.Gameplay.Windows;
using Code.Infrastructure.Services.Level;
using Code.Infrastructure.StateMachine.Game;
using Code.Infrastructure.States.Abstract;

namespace Code.Infrastructure.States
{
    public class BattleEnterState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IFighterFactory _fighterFactory;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IWindowService _windowService;

        public BattleEnterState(
            IGameStateMachine gameStateMachine,
            IFighterFactory fighterFactory,
            ILevelDataProvider levelDataProvider,
            IWindowService windowService)
        {
            _gameStateMachine = gameStateMachine;
            _fighterFactory = fighterFactory;
            _levelDataProvider = levelDataProvider;
            _windowService = windowService;
        }

        public void Enter()
        {
            CreateHUD();
            PlaceFighters();
            _gameStateMachine.Enter<BattleLoopState>();
        }

        public void Update() { }

        public void Exit() { }

        private void CreateHUD() => _windowService.Open(WindowId.HUD);

        private void PlaceFighters()
        {
            GameEntity hero = _fighterFactory.CreateFighter(_levelDataProvider.LeftSocket);
            GameEntity enemy = _fighterFactory.CreateFighter(_levelDataProvider.RightSocket);

            hero.AddTargetId(enemy.Id);
            enemy.AddTargetId(hero.Id);
            
            hero.isActive = true;
        }
    }
}
