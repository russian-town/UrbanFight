using Entitas;

namespace Code.Gameplay.Features.AbilityAnimation
{
    [Game] public class BaseAnimationStateComponent : IComponent { public BaseAnimationState Value; }
    [Game] public class ActionAnimationStateComponent : IComponent { public ActionAnimationState Value; }
    [Game] public class ReactionAnimationStateComponent : IComponent { public ReactionAnimationState Value; }
    
    [Game] public class BaseAnimationWeight : IComponent { public float Value; }
    [Game] public class ActionAnimationWeight : IComponent { public float Value; }
    [Game] public class ReactionAnimationWeight : IComponent { public float Value; }
    
    [Game] public class Knockback : IComponent { }
}
