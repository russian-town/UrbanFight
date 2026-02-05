using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class MovementToTargetSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movers;
        private readonly List<GameEntity> _buffer = new(16);

        public MovementToTargetSystem(GameContext game, ITimeService time)
        {
            _time = time;

            _movers = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.WorldPosition,
                        GameMatcher.MoveProgress,
                        GameMatcher.TargetPosition,
                        GameMatcher.StartPosition,
                        GameMatcher.Duration)
                    .NoneOf(GameMatcher.DestinationReached));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers.GetEntities(_buffer))
            {
                float step = _time.DeltaTime / mover.Duration;
                mover.ReplaceMoveProgress(Mathf.Clamp01(mover.MoveProgress + step));
                Vector3 targetPosition = Vector3.Lerp(mover.StartPosition, mover.TargetPosition, mover.MoveProgress);
                mover.ReplaceWorldPosition(targetPosition);

                if (mover.MoveProgress < 1f)
                    continue;

                mover.isDestinationReached = true;
            }
        }
    }
}
