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
        private readonly IRandomService _randomService;
        private readonly IStaticDataService _staticDataService;

        public AbilitySolver(IRandomService randomService, IStaticDataService staticDataService)
        {
            _randomService = randomService;
            _staticDataService = staticDataService;
        }
        
        public AbilityConfig GetRandomOffensiveAbility(FighterTypeId by)
        {
            var randomChance = _randomService.Range(0f, 1f); 
            
            IEnumerable<AbilityConfig> abilityConfigs = _staticDataService.GetAbilityConfigsByFighterTypeId(by);
            
            return abilityConfigs
                .OrderBy(x => x.Chanse)
                .First(x => x.Chanse >= randomChance);
        }
    }
}
