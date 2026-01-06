using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Factories;
using Code.Infrastructure.Services.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Request.Systems
{
    public class CastСounterattackAbilitySystem : IExecuteSystem
    {
        private readonly IAbilityFactory _abilityFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IGroup<GameEntity> _requests;
        private readonly IGroup<GameEntity> _fighters;
        private readonly List<GameEntity> _buffer = new(64);

        public CastСounterattackAbilitySystem(GameContext game, IAbilityFactory abilityFactory, IStaticDataService staticDataService)
        {
            _abilityFactory = abilityFactory;
            _staticDataService = staticDataService;

            _requests = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Request,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.Сounterattacked,
                    GameMatcher.Processed)
                    .NoneOf(GameMatcher.Destructed));
            
            _fighters = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Id,
                    GameMatcher.Fighter,
                    GameMatcher.FighterTypeId));
        }

        public void Execute()
        {
            foreach (GameEntity request in _requests.GetEntities(_buffer))
            foreach (GameEntity fighter in _fighters)
            {
                if(fighter.Id != request.TargetId)
                    continue;

                AbilityConfig abilityConfig = _staticDataService
                    .GetAbilityConfigsByFighterTypeId(fighter.FighterTypeId)
                    .First(x => x.TypeId == AbilityTypeId.Counterattack);
                
                _abilityFactory.CreateAbility(abilityConfig, request.TargetId, request.ProducerId);
                fighter.FighterAnimator.PlayCounterattack();
                request.isDestructed = true;
            }
        }
    }
}
