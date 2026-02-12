using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Combats.Setups;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Combats
{
    [Game] public sealed class CombatReady : IComponent { }
    [Game] public sealed class Attacker : IComponent { }
    [Game] public sealed class Defender : IComponent { }

    [Game] public sealed class AttackAbility : IComponent { public AbilityConfig Value; }
    [Game] public sealed class BlockAbility : IComponent { public AbilityConfig Value; }
    [Game] public sealed class CounterAttackAbility : IComponent { public AbilityConfig Value; }
    [Game] public sealed class DodgeAbility : IComponent { public AbilityConfig Value; }

    [Game] public sealed class AbilityTarget : IComponent { public int Value; }
    [Game] public sealed class AbilityExecutionStateComponent : IComponent { public AbilityExecutionState Value; }

    [Game] public sealed class Position : IComponent { public Vector3 Value; }
    [Game] public sealed class AnimationTelegraphComponent : IComponent { public AnimationTelegraph Value; }

    [Game] public sealed class Dodge : IComponent { public bool Value; }
    [Game] public sealed class SkipNextTurn : IComponent { public float Value; }
    [Game] public sealed class TelegraphPhase : IComponent { }
    [Game] public sealed class ReactionWindow : IComponent { }
    [Game] public sealed class EffectResolutionPhase : IComponent { }
    [Game] public sealed class StatusResolutionPhase : IComponent { }
    [Game] public sealed class TurnResolutionPhase : IComponent { }
    [Game] public sealed class DamageModifier : IComponent { }
    [Game] public sealed class CancelNextHit : IComponent { }
}
