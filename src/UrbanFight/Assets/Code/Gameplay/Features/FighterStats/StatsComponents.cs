using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.FighterStats
{
    [Game] public class BaseStats : IComponent { public Dictionary<StatTypeId, float> Value; }
    [Game] public class StatModifiers : IComponent { public Dictionary<StatTypeId, float> Value; }
  
    [Game] public class StatChange : IComponent { public StatTypeId Value; }
    [Game] public class EffectValue : IComponent { public float Value; }
}
