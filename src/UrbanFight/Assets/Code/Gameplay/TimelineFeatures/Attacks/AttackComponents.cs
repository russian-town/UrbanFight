using Entitas;

namespace Code.Gameplay.TimelineFeatures.Attacks
{
    [Game] public class AttackTrack : IComponent {}
    [Game] public class HitStartTime : IComponent { public float Value; }
    [Game] public class HitEndTime : IComponent { public float Value; }
}
