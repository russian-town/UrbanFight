using Code.Infrastructure.StateMachine.Game;
using Code.Infrastructure.States.Abstract;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class BattleEnterState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public BattleEnterState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            Debug.Log("Enter to battle enter state.");
            
            //  TODO: CreateFighters and more

            _gameStateMachine.Enter<BattleLoopState>();
        }

        public void Update() { }

        public void Exit() { }
    }
}
