using Code.Common.Destruct;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.FighterStats;
using Code.Gameplay.Features.Movement;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay.Features
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<BindViewFeature>());
            
            Add(systems.Create<FighterStatsFeature>());
            Add(systems.Create<EffectFeature>());
            
            Add(systems.Create<MovementFeature>());
            
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}
