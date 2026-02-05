using System;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Configs
{
    [Serializable]
    public class MovementPhase
    {
        public MovementPhaseType Type;
        public float Duration;
        public Vector3 Offset;
        public AnimationCurve Curve;
    }
}
