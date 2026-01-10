using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities.Behaviours;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Factories;
using Code.Gameplay.Features.Fighter;
using Code.Infrastructure.Services.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class ShowAbilityItemsSystem : IExecuteSystem
    {
        private readonly IAbilityItemFactory _abilityItemFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _abilityHolders;
        private readonly List<GameEntity> _buffer = new(16);

        public ShowAbilityItemsSystem(
            GameContext game,
            IAbilityItemFactory abilityItemFactory,
            IStaticDataService staticDataService)
        {
            _abilityItemFactory = abilityItemFactory;
            _staticDataService = staticDataService;

            _abilities = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.Ability,
                        GameMatcher.ProducerId)
                    .NoneOf(GameMatcher.Showed));

            _abilityHolders = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.AbilityHolder,
                    GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            foreach (GameEntity abilityHolder in _abilityHolders)
            {
                if (ability.ProducerId != abilityHolder.TargetId)
                    continue;

                AbilityConfig config = _staticDataService
                    .GetAbilityConfigsByFighterTypeId(FighterTypeId.Ganz)
                    .First(x => x.TypeId == ability.AbilityTypeId);

                AbilityItem abilityItem =
                    _abilityItemFactory.CreateAbilityItem(abilityHolder.AbilityHolder.AbilityHolderLayout);
                abilityItem.Setup(config);
                ability.isShowed = true;
            }
        }
    }
}
