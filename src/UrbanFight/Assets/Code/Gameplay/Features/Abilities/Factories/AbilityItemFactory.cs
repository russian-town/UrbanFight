using Code.Gameplay.Features.Abilities.Behaviours;
using Code.Infrastructure.Services.Assets;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Factories
{
    public class AbilityItemFactory : IAbilityItemFactory
    {
        private const string PathToAbilityItemPrefab = "Prefabs/UI/HUD/Abilities/AbilityItem";
        
        private readonly IAssetProvider _assetProvider;

        public AbilityItemFactory(IAssetProvider assetProvider) =>
            _assetProvider = assetProvider;

        public AbilityItem CreateAbilityItem(RectTransform parent)
        {
            AbilityItem template = _assetProvider.LoadAsset<AbilityItem>(PathToAbilityItemPrefab);
            return Object.Instantiate(template, parent);
        }
    }
}
