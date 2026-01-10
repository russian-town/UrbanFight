using Code.Gameplay.Features.Abilities.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Factories
{
    public interface IAbilityItemFactory
    {
        AbilityItem CreateAbilityItem(RectTransform parent);
    }
}
