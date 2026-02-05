using Entitas;

namespace Code.Gameplay.Features.Timelines
{
    [Game] public class  CombatTimeline  : IComponent { public float Value; }
    [Game] public class  NormalizedTime  : IComponent { public float Value; }
    [Game] public class  Timeline  : IComponent { }
    [Game] public class  Started  : IComponent { }
    [Game] public class  Completed  : IComponent { }
}
