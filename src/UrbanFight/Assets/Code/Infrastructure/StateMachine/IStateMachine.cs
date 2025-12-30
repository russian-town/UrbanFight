using System;
using Code.Infrastructure.States;

namespace Code.Infrastructure.StateMachine
{
    public interface IStateMachine : IDisposable
    {
        public void Enter<TState>() where TState : class, IState;
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
        public void Update();
    }
}
