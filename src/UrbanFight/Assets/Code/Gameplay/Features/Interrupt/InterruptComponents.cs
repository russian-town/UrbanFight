using Entitas;

namespace Code.Gameplay.Interrupt
{
    [Game] public class InterruptTypeIdComponent : IComponent { public InterruptTypeId Value; }
    [Game] public class SkipNextTurn : IComponent { }
    [Game] public class ForceEndTurn : IComponent { }
}
