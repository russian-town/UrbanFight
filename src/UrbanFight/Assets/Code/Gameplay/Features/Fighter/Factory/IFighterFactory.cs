using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Factory
{
    public interface IFighterFactory
    {
        GameEntity CreateFighter(Transform socket);
    }
}
