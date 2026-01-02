using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Factories;
using Code.Gameplay.Features.Abilities.Services;
using Entitas;

namespace Code.Gameplay.Features.Turn.System
{
    public class RequestOffensiveAbilityByActiveFightersSystem : IExecuteSystem
    {
        private readonly IAbilitySolver _abilitySolver;
        private readonly IAbilityFactory _abilityFactory;
        private readonly IGroup<GameEntity> _fighters;

        public RequestOffensiveAbilityByActiveFightersSystem(
            GameContext game,
            IAbilitySolver abilitySolver,
            IAbilityFactory abilityFactory)
        {
            _abilitySolver = abilitySolver;
            _abilityFactory = abilityFactory;

            _fighters = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Id,
                    GameMatcher.Fighter,
                    GameMatcher.FighterTypeId,
                    GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (GameEntity fighter in _fighters)
            {
                AbilityConfig config = _abilitySolver.GetRandomOffensiveAbility(by: fighter.FighterTypeId);
                _abilityFactory.CreateAbility(config);
                fighter.isActive = false;
            }
        }
    }
}
