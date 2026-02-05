using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class ApplyCounterAttackStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _targets;
        private readonly IGroup<GameEntity> _producers;
        private readonly List<GameEntity> _buffer = new(16);

        public ApplyCounterAttackStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.Status,
                        GameMatcher.Counterattack,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId)
                    .NoneOf(GameMatcher.Applied));

            _producers = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.FighterAnimator,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses.GetEntities(_buffer))
            foreach (GameEntity producer in _producers)
            {
                if (status.ProducerId != producer.Id)
                    continue;

                status.isApplied = true;
            }
        }
    }
}
