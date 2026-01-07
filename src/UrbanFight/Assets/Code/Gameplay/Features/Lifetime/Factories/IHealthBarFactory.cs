using UnityEngine;

namespace Code.Gameplay.Features.Lifetime.Factories
{
    public interface IHealthBarFactory
    {
        GameEntity CreateHealthBar(int targetId, RectTransform parent);
    }
}
