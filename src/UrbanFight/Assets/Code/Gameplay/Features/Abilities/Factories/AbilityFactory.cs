using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Services;
using Code.Gameplay.Features.Effects;
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

        public GameEntity CreateAbility(AbilityConfig config, int producerId, int targetId)
        {
            GameEntity entity = CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.AddAbilityTypeId(config.TypeId))
                .With(x => x.isAbility = true)
                .With(x => x.isBlockable = true, when: config.Blockable)
                .AddCooldown(config.Cooldown)
                .AddCooldownLeft(config.Cooldown);

            switch (config.TypeId)
            {
                case AbilityTypeId.BaseAttack:
                    return CreateBaseAttack(entity, config);
                case AbilityTypeId.Block:
                    return CreateBlock(entity);
            }

            throw new ArgumentException($"Ability with type id {config.TypeId} is incorrect.");
        }

        private GameEntity CreateBaseAttack(GameEntity entity, AbilityConfig config)
        {
            int currentAbilityLevel = _abilityUpgradeService.GetCurrentAbilityLevel(config.TypeId) - 1;
            List<EffectSetup> effectSetups = config.Levels[currentAbilityLevel].EffectSetups;
            
            return entity
                .With(x => x.isBaseAttack = true)
                .With(x => x.AddEffectSetups(effectSetups), when: !effectSetups.IsNullOrEmpty());
        }

        private static GameEntity CreateBlock(GameEntity entity) =>
            entity.With(x => x.isBlock = true);
    }
}
