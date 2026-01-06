using System;
using System.Collections.Generic;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Factories;
using Code.Gameplay.Features.Abilities.Services;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Request.Systems
{
    public class TryBlockRequestSystem : IExecuteSystem
    {
        private readonly IAbilitySolver _abilitySolver;
        private readonly IRandomService _random;
        private readonly IAbilityFactory _abilityFactory;
        private readonly IGroup<GameEntity> _requests;
        private readonly IGroup<GameEntity> _fighters;
        private readonly List<GameEntity> _buffer = new(64);

        public TryBlockRequestSystem(
            GameContext game,
            IAbilitySolver abilitySolver,
            IRandomService random,
            IAbilityFactory abilityFactory)
        {
            _abilitySolver = abilitySolver;
            _random = random;
            _abilityFactory = abilityFactory;

            _requests = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.Request,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId)
                    .NoneOf(GameMatcher.Processed));

            _fighters = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.Id,
                    GameMatcher.FighterTypeId));
        }

        public void Execute()
        {
            foreach (GameEntity fighter in _fighters)
            foreach (GameEntity request in _requests.GetEntities(_buffer))
            {
                if (fighter.Id != request.TargetId)
                    continue;

                AbilityConfig defenseAbility = _abilitySolver
                    .GetRandomDefenseAbility(
                        fighter.FighterTypeId,
                        _random.GetChance());

                if (defenseAbility == null)
                    continue;

                switch (defenseAbility.TypeId)
                {
                    case AbilityTypeId.Block:
                        request.isBlocked = true;
                        break;
                    case AbilityTypeId.Counterattack:
                        request.isСounterattacked = true;
                        break;
                }
                
                request.isProcessed = true;
            }
        }
    }
}
