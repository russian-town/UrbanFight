namespace Code.Infrastructure.States.Abstract
{
    public interface IState
    {
        public void Enter();
        public void Update();
        public void Exit();
    }
}
