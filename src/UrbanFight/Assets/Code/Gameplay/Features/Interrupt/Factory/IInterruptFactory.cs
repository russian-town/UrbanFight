namespace Code.Gameplay.Interrupt.Factory
{
    public interface IInterruptFactory
    {
        GameEntity CreateInterrupt(int targetId, InterruptTypeId typeId);
    }
}
