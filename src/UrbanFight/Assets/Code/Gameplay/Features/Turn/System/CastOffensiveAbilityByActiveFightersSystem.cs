using System.Collections.Generic;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Factories;
using Code.Gameplay.Features.Abilities.Services;
using Entitas;

namespace Code.Gameplay.Features.Turn.System
{
    public class CastOffensiveAbilityByActiveFightersSystem : IExecuteSystem
    {
        private readonly IRandomService _random;
        private readonly IAbilitySolver _abilitySolver;
        private readonly IAbilityFactory _abilityFactory;
        private readonly IGroup<GameEntity> _fighters;
        private readonly List<GameEntity> _buffer = new(2);

        public CastOffensiveAbilityByActiveFightersSystem(
            GameContext game,
            IRandomService random,
            IAbilitySolver abilitySolver,
            IAbilityFactory abilityFactory)
        {
            _random = random;
            _abilitySolver = abilitySolver;
            _abilityFactory = abilityFactory;

            _fighters = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Id,
                    GameMatcher.TargetId,
                    GameMatcher.Fighter,
                    GameMatcher.FighterTypeId,
                    GameMatcher.Active));
        }

        public void Execute()
        {
            foreach (GameEntity fighter in _fighters.GetEntities(_buffer))
            {
                AbilityConfig config = _abilitySolver.GetRandomOffensiveAbility(
                    fighter.FighterTypeId,
                    _random.GetChance());

                _abilityFactory.CreateAbility(config, fighter.Id, fighter.TargetId);
                fighter.isActive = false;
            }
        }
    }
}
