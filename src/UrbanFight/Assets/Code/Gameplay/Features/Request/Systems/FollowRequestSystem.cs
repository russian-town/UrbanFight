using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Services;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Code.Infrastructure.Services.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Request.Systems
{
    public class FollowRequestSystem : IExecuteSystem
    {
        private readonly IEffectFactory _effectFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IAbilityUpgradeService _abilityUpgradeService;
        private readonly IGroup<GameEntity> _requests;
        private readonly IGroup<GameEntity> _fighters;
        private readonly List<GameEntity> _buffer = new(64);

        public FollowRequestSystem(
            GameContext game,
            IEffectFactory effectFactory,
            IStaticDataService staticDataService,
            IAbilityUpgradeService abilityUpgradeService)
        {
            _effectFactory = effectFactory;
            _staticDataService = staticDataService;
            _abilityUpgradeService = abilityUpgradeService;

            _requests = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.Request,
                        GameMatcher.ProducerId,
                        GameMatcher.ParentAbilityId,
                        GameMatcher.TargetId)
                    .NoneOf(GameMatcher.Processed));

            _fighters = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.FighterTypeId,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity request in _requests.GetEntities(_buffer))
            foreach (GameEntity fighter in _fighters)
            {
                if (fighter.Id != request.ProducerId)
                    continue;

                IEnumerable<AbilityConfig> abilityConfigs = _staticDataService
                    .GetAbilityConfigsByFighterTypeId(fighter.FighterTypeId);
                AbilityConfig abilityConfig = abilityConfigs.First(x => x.TypeId == request.ParentAbilityId);
                List<EffectSetup> effectSetups = abilityConfig
                    .Levels[_abilityUpgradeService.GetCurrentAbilityLevel(request.ParentAbilityId) - 1]
                    .EffectSetups;

                foreach (EffectSetup effectSetup in effectSetups)
                {
                    _effectFactory.CreateEffect(
                        effectSetup,
                        request.ProducerId,
                        GetTargetId(effectSetup, request));
                }

                switch (abilityConfig.TypeId)
                {
                    case AbilityTypeId.BaseAttack:
                        fighter.FighterAnimator.PlayBaseAttack();
                        break;
                }
                
                request.isProcessed = true;
            }
        }

        private static int GetTargetId(EffectSetup effectSetup, GameEntity request)
        {
            return effectSetup.TargetTypeId == TargetTypeId.Enemy
                ? request.TargetId
                : request.ProducerId;
        }
    }
}
