using Code.Gameplay.Features.Request.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Request
{
    public class RequestFeature : Feature
    {
        public RequestFeature(ISystemFactory systems)
        {
            Add(systems.Create<TryBlockRequestSystem>());
            Add(systems.Create<CastBlockAbilitySystem>());
            Add(systems.Create<CastСounterattackAbilitySystem>());
            
            Add(systems.Create<FollowRequestSystem>());
        }
    }
}
