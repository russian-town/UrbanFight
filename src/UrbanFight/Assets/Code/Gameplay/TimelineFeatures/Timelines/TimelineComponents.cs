using Entitas;

namespace Code.Gameplay.TimelineFeatures.Timelines
{
    [Game] public class Timeline : IComponent { }
    [Game] public class TimelineOwnerId : IComponent { public int Value; }
    [Game] public class TimelineTargetId : IComponent { public int Value; }
    [Game] public class TimelineDuration : IComponent { public float Value; }
    [Game] public class TimelineTime : IComponent { public float Value; }
    [Game] public class TimelineNormalizedTime : IComponent { public float Value; }
    [Game] public class ActiveTimeline : IComponent { }
    [Game] public class InterruptPriority : IComponent { public int Value; }
    [Game] public class ReactionCreated : IComponent { }
    [Game] public class PreviousNormalizedTime : IComponent { public float Value; }
}
