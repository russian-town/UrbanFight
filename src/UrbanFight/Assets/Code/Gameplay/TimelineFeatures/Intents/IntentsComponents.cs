using Entitas;

namespace Code.Gameplay.TimelineFeatures.Intents
{
    [Game] public class IntentTypeIdComponent : IComponent { public IntentTypeId Value; }
    [Game] public class AbilityIntent : IComponent { }
    [Game] public class DamageIntent : IComponent { }
    [Game] public class InterruptIntent : IComponent { }
    [Game] public class MovementIntent : IComponent { }
    [Game] public class TurnIntent : IComponent { }
}
