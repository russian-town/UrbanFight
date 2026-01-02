using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Fighter;

namespace Code.Gameplay.Features.Abilities.Services
{
    public interface IAbilitySolver
    {
        AbilityConfig GetRandomOffensiveAbility(FighterTypeId by);
    }
}
