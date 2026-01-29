using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Turn
{
    [Game] public class TurnStateComponent : IComponent { public TurnState Value; }
    [Game] public class TurnQueue : IComponent { public Queue<GameEntity> Value; }
    [Game] public class TurnOwner : IComponent { }
    
    [Game] public class AttackIntent : IComponent { public int Value; }
    [Game] public class Initiative : IComponent { public int Value; }
    
    [Game] public class AbilityCasting : IComponent { }
    [Game] public class AbilityHitMoment : IComponent { }
}
