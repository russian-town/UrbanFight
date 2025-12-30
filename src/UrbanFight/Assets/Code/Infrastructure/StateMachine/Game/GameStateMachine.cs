using Code.Infrastructure.States.Abstract;
using Code.Infrastructure.States.Factories;
using Zenject;

namespace Code.Infrastructure.StateMachine.Game
{
    public class GameStateMachine : IGameStateMachine, ITickable
    {
        private readonly IStateFactory _stateFactory;

        private IState _activeState;

        public GameStateMachine(IStateFactory stateFactory) => _stateFactory = stateFactory;

        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        public void Update() { }

        public void Tick() => _activeState?.Update();

        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            var state = _stateFactory.GetState<TState>();
            _activeState = state;
            return state;
        }

        public void Dispose() => _activeState?.Exit();
    }
}
