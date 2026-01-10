using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Behaviours;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.Abilities
{
    [Game] public class AbilityTypeIdComponent : IComponent { public AbilityTypeId Value; }
    [Game] public class ParentAbilityId : IComponent { public AbilityTypeId Value; }
    [Game] public class BattleTypeIdComponent : IComponent { public BattleTypeId Value; }
    [Game] public class Duration : IComponent { public float Value; }
    [Game] public class DamagePerCast : IComponent { public float Value; }
    [Game] public class HealPerCast : IComponent { public float Value; }
    [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value; }
    
    [Game] public class AbilityHolderComponent : IComponent { public AbilityHolder Value; }
    
    [Game] public class Ability : IComponent { }
    [Game] public class BaseAttack : IComponent { }
    [Game] public class Block : IComponent { }
    [Game] public class Counterattack : IComponent { }
    
    [Game] public class Blockable : IComponent { }
    [Game] public class Casted : IComponent { }
    [Game] public class Showed : IComponent { }
    [Game] public class AnimatedWait : IComponent { }
}
