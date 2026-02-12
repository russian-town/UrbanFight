using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Statuses;
using Entitas;

namespace Code.Gameplay.Features.Combats.Systems
{
    public class ApplyDodgeStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);

        public ApplyDodgeStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.Status,
                        GameMatcher.TargetId,
                        GameMatcher.StatusTypeId)
                    .NoneOf(GameMatcher.Affected));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses.GetEntities(_buffer))
            {
                if (status.StatusTypeId != StatusTypeId.Dodge)
                    continue;

                CreateEntity.Empty()
                    .With(x => x.isCancelNextHit = true)
                    .AddTargetId(status.TargetId);

                status.isAffected = true;
            }
        }
    }
}
