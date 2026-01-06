using System;
using Code.Gameplay.Features.Abilities.Configs;

namespace Code.Gameplay.Features.Effects
{
    [Serializable]
    public class EffectSetup
    {
        public EffectTypeId EffectTypeId;
        public TargetTypeId TargetTypeId;
        public float Value;
    }
}
