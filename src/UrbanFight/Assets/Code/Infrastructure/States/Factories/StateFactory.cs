using Zenject;

namespace Code.Infrastructure.States.Factories
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container) => _container = container;

        public T GetState<T>() where T : class, IState => _container.Resolve<T>();
    }
}
