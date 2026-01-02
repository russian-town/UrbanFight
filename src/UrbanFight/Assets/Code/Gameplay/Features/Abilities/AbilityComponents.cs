using Entitas;

namespace Code.Gameplay.Features.Abilities
{
    [Game] public class Duration : IComponent { public float Value; }
    [Game] public class DamagePerCast : IComponent { public float Value; }
    [Game] public class HealPerCast : IComponent { public float Value; }
    
    [Game] public class BaseAttack : IComponent { }
    
    [Game] public class Casted : IComponent { }
}
