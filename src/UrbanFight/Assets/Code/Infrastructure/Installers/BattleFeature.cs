using Code.Infrastructure.Systems;

namespace Code.Infrastructure.Installers
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            //Add(systemFactory.Create<Systems>());
        }
    }
}
