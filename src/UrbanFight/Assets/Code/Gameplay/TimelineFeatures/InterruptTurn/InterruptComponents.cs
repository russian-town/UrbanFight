using Entitas;

namespace Code.Gameplay.TimelineFeatures.InterruptTurn
{
    [Game] public class CausesInterrupt : IComponent { }
    [Game] public class InterruptRequest : IComponent { }
    
    [Game] public class InterruptType : IComponent { public InterruptTypeId Value; }
    [Game] public class InterruptTargetId : IComponent { public int Value; }
}
