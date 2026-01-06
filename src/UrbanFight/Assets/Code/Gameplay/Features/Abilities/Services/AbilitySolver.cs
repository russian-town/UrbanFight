using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Fighter;
using Code.Infrastructure.Services.StaticData;

namespace Code.Gameplay.Features.Abilities.Services
{
    public class AbilitySolver : IAbilitySolver
    {
        private readonly IRandomService _random;
        private readonly IStaticDataService _staticDataService;

        public AbilitySolver(IRandomService random, IStaticDataService staticDataService)
        {
            _random = random;
            _staticDataService = staticDataService;
        }

        public AbilityConfig GetRandomOffensiveAbility(FighterTypeId fighterTypeId, float randomChance) =>
            GetSortedAbilitiesByType(BattleTypeId.Offensive, fighterTypeId)
                .First(x => x.Chanse >= randomChance);

        public AbilityConfig GetRandomDefenseAbility(FighterTypeId fighterTypeId, float randomChance) =>
            GetSortedAbilitiesByType(BattleTypeId.Defense, fighterTypeId)
                .FirstOrDefault(x => x.Chanse >= randomChance);

        private IEnumerable<AbilityConfig> GetSortedAbilitiesByType(
            BattleTypeId battleTypeId,
            FighterTypeId fighterTypeId)
        {
            IEnumerable<AbilityConfig> abilityConfigs =
                _staticDataService.GetAbilityConfigsByFighterTypeId(fighterTypeId);

            return abilityConfigs
                .Where(x => x.BattleTypeId == battleTypeId)
                .OrderBy(x => x.Chanse);
        }
    }
}
