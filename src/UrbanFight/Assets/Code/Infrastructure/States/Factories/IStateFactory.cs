namespace Code.Infrastructure.States.Factories
{
    public interface IStateFactory
    {
        T GetState<T>() where T : class, IState;
    }
}
