namespace Code.Infrastructure.States
{
    public interface IPayloadState<TPayload> : IState
    {
        public void Enter(TPayload payload);
    }
}
