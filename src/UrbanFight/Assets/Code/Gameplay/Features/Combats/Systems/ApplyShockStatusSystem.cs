using System.Collections.Generic;
using Code.Common.Entity;
using Code.Gameplay.Features.Statuses;
using Entitas;

namespace Code.Gameplay.Features.Combats.Systems
{
    public class ApplyShockStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);

        public ApplyShockStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.Status,
                        GameMatcher.EffectValue,
                        GameMatcher.TargetId,
                        GameMatcher.StatusTypeId)
                    .NoneOf(GameMatcher.Affected));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses.GetEntities(_buffer))
            {
                if (status.StatusTypeId != StatusTypeId.Shock)
                    continue;

                CreateEntity.Empty()
                    .AddSkipNextTurn(status.EffectValue)
                    .AddTargetId(status.TargetId);

                status.isAffected = true;
            }
        }
    }
}
