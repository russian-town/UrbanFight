using Code.Gameplay.Features.Abilities;

namespace Code.Gameplay.Features.Request.Factory
{
    public interface IRequestFactory
    {
        GameEntity CreateRequest(AbilityTypeId ability, int producerId, int targetId);
    }
}
