using Code.Gameplay.Features.Fighter.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Fighter
{
    [Game] public class Fighter : IComponent { }
    [Game] public class Active : IComponent { }
    [Game] public class FighterTypeIdComponent : IComponent { public FighterTypeId Value; }
    [Game] public class FighterAnimatorComponent : IComponent { public FighterAnimator Value; }
    [Game] public class BaseHealth : IComponent { public float Value; }
    [Game] public class BaseDamage : IComponent { public float Value; }
    [Game] public class BaseArmor : IComponent { public float Value; }
}
