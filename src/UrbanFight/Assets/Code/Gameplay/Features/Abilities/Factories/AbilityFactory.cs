using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Services;
using Code.Infrastructure.Services.Identifiers;

namespace Code.Gameplay.Features.Abilities.Factories
{
    public class AbilityFactory : IAbilityFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IAbilityUpgradeService _abilityUpgradeService;

        public AbilityFactory(IIdentifierService identifiers, IAbilityUpgradeService abilityUpgradeService)
        {
            _identifiers = identifiers;
            _abilityUpgradeService = abilityUpgradeService;
        }
        
        public GameEntity CreateAbility(AbilityConfig config)
        {
            var currentAbilityLevel = _abilityUpgradeService.GetCurrentAbilityLevel(config.TypeId) - 1;
            var damage = config.Levels[currentAbilityLevel].Damage;
            var heal = config.Levels[currentAbilityLevel].Heal;

            GameEntity entity = CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .With(x => x.AddDamagePerCast(damage), when: damage > 0f)
                .With(x => x.AddDamagePerCast(heal), when: heal > 0f);

            switch (config.TypeId)
            {
                case AbilityTypeId.BaseAttack:
                    return CreateBaseAttack(entity);
            }

            throw new ArgumentException($"Ability with type id {config.TypeId} is incorrect.");
        }

        private GameEntity CreateBaseAttack(GameEntity entity) =>
            entity.With(x => x.isBaseAttack = true);
    }
}
