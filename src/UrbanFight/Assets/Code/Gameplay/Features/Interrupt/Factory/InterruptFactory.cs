using Code.Common.Entity;

namespace Code.Gameplay.Interrupt.Factory
{
    public class InterruptFactory : IInterruptFactory
    {
        public GameEntity CreateInterrupt(int targetId, InterruptTypeId typeId)
        {
            return CreateEntity.Empty()
                .AddTargetId(targetId)
                .AddInterruptTypeId(typeId);
        }
    }
}
