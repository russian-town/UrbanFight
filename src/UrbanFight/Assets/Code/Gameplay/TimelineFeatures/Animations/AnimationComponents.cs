using Entitas;

namespace Code.Gameplay.TimelineFeatures.Animations
{
    [Game] public class AnimationTrack : IComponent { }
    [Game] public class AnimationStateId : IComponent { public int Value; }
    [Game] public class AnimationTypeIdComponent : IComponent { public AnimationTypeId Value; }
    [Game] public class BaseAnimationStateId : IComponent { public int Value; }
    [Game] public class ActionAnimationStateId : IComponent { public int Value; }
    [Game] public class ReactionAnimationStateId : IComponent { public int Value; }
}
