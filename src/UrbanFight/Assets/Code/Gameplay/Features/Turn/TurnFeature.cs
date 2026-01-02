using Code.Gameplay.Features.Turn.System;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Turn
{
    public class TurnFeature : Feature
    {
        public TurnFeature(ISystemFactory systems)
        {
            Add(systems.Create<RequestOffensiveAbilityByActiveFightersSystem>());
        }
    }
}
