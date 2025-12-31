using Code.Infrastructure.Loading;
using Code.Infrastructure.Services.StaticData;
using Code.Infrastructure.StateMachine.Game;
using Code.Infrastructure.States.Abstract;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(
            IGameStateMachine gameStateMachine,
            ISceneLoader sceneLoader,
            IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            Debug.Log("Enter To bootstrap");
            
            _staticDataService.Load();
            _sceneLoader.LoadScene(Scenes.Initial, OnInitialSceneLoaded);
        }

        public void Update() { }

        public void Exit() { }

        private void OnInitialSceneLoaded()
        {
            //TODO: Enter to LoadProgress state
            
            _gameStateMachine.Enter<LoadingBattleState, string>(Scenes.Arena);
        }
    }
}
