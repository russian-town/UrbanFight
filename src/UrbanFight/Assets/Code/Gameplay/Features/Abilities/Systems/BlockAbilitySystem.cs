using System.Collections.Generic;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class BlockAbilitySystem : IExecuteSystem
    {
        private readonly IStatusFactory _statusFactory;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public BlockAbilitySystem(GameContext game, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;

            _abilities = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.Ability,
                        GameMatcher.AbilityTypeId,
                        GameMatcher.StatusSetups,
                        GameMatcher.Block,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId
                    )
                    .NoneOf(GameMatcher.Casted));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                foreach (StatusSetup statusSetup in ability.StatusSetups)
                    _statusFactory.CreateStatus(statusSetup, ability.ProducerId, ability.TargetId);

                ability.isCasted = true;
            }
        }
    }
}
