using Code.Infrastructure.Loading;
using Code.Infrastructure.StateMachine.Game;
using Code.Infrastructure.States.Abstract;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class LoadingBattleState : IPayloadState<string>
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISceneLoader _sceneLoader;

        public LoadingBattleState(IGameStateMachine gameStateMachine, ISceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string battleSceneName)
        {
            Debug.Log("Enter to load battle state.");
            
            _sceneLoader.LoadScene(battleSceneName, OnBattleSceneLoaded);
        }

        public void Enter() { }

        public void Update() { }

        public void Exit() { }

        private void OnBattleSceneLoaded() =>
            _gameStateMachine.Enter<BattleEnterState>();
    }
}
