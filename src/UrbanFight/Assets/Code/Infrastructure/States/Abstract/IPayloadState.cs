namespace Code.Infrastructure.States.Abstract
{
    public interface IPayloadState<TPayload> : IState
    {
        public void Enter(TPayload payload);
    }
}
