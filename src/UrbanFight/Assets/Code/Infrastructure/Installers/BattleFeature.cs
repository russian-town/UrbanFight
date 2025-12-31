using Code.Common.Destruct;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Infrastructure.Installers
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<BindViewFeature>());
            
            Add(systems.Create<ProcessDestructedFeature>());
        }
    }
}
