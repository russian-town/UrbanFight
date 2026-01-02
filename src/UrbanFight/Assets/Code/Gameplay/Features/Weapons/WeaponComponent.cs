using Entitas;

namespace Code.Gameplay.Features.Weapons
{
    [Game] public class WeaponTypeIdComponent : IComponent { public WeaponTypeId Value; }
    [Game] public class ShootCount : IComponent { public int Value; }
    [Game] public class DamagePerShoot : IComponent { public float Value; }
    
    [Game] public class DesertEagle : IComponent { }
}
