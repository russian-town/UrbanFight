using Entitas;

namespace Code.Gameplay.TimelineFeatures.Movements
{
    [Game] public class MovementTrack : IComponent { }
    [Game] public class MovementType : IComponent { public MovementTypeId Value; }
    [Game] public class MoveStartTime : IComponent { public float Value; }
    [Game] public class MoveEndTime : IComponent { public float Value; }
}
