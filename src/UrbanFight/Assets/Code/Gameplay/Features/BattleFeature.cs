using Code.Common.Destruct;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Cooldowns.Systems;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.FighterStats;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.Request;
using Code.Gameplay.Features.Turn;
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
            Add(systems.Create<MovementFeature>());
            
            Add(systems.Create<TurnFeature>());
            Add(systems.Create<AbilityFeature>());
            Add(systems.Create<RequestFeature>());
            Add(systems.Create<EffectFeature>());
            
            Add(systems.Create<CooldownSystem>());
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}
