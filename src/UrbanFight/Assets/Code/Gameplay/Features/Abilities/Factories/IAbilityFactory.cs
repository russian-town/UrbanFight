using Code.Gameplay.Features.Abilities.Configs;

namespace Code.Gameplay.Features.Abilities.Factories
{
    public interface IAbilityFactory
    {
        GameEntity CreateAbility(AbilityConfig config);
    }
}
