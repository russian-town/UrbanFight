using Code.Gameplay.Features.FighterStats.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.FighterStats
{
    public class FighterStatsFeature : Feature
    {
        public FighterStatsFeature(ISystemFactory systems)
        {
            Add(systems.Create<StatChangeSystem>());
        }
    }
}
