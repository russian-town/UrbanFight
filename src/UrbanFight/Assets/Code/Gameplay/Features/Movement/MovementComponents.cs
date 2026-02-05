using System.Collections.Generic;
using Code.Gameplay.Features.Movement.Configs;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
    [Game] public class StartPosition : IComponent { public Vector3 Value; }
    [Game] public class TargetPosition : IComponent { public Vector3 Value; }
    
    [Game] public class MoveProgress : IComponent { public float Value; }
    [Game] public class CurrentPhaseIndex : IComponent { public int Value; }
    [Game] public class PhaseElapsed : IComponent { public float Value; }
    [Game] public class PhaseStartPosition : IComponent { public Vector3 Value; }
    [Game] public class Phases : IComponent { public List<MovementPhase> Value; }
    [Game] public class DestinationReached : IComponent { }
}
