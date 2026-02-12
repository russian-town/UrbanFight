using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    [Game] public class StartPosition : IComponent { public Vector3 Value; }
    [Game] public class TargetPosition : IComponent { public Vector3 Value; }
    
    [Game] public class MoveProgress : IComponent { public float Value; }
    [Game] public class DestinationReached : IComponent { }
    [Game] public class MoveStartTime : IComponent { public float Value; }
    [Game] public class MoveEndTime : IComponent { public float Value; }
}
