using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Movement.Configs;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class MultiPhaseMovementSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _movers;
        private readonly IGroup<GameEntity> _timelines;
        private readonly List<GameEntity> _buffer = new(16);

        public MultiPhaseMovementSystem(GameContext game, ITimeService time)
        {
            _time = time;

            _movers = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.Id,
                        GameMatcher.Phases,
                        GameMatcher.Duration,
                        GameMatcher.PhaseStartPosition,
                        GameMatcher.FighterAnimator,
                        GameMatcher.WorldPosition,
                        GameMatcher.CurrentPhaseIndex)
                    .NoneOf(GameMatcher.DestinationReached));

            _timelines = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Timeline,
                    GameMatcher.NormalizedTime,
                    GameMatcher.ProducerId));
        }

        public void Execute()
        {
            foreach (GameEntity mover in _movers.GetEntities(_buffer))
            foreach (GameEntity timeline in _timelines)
            {
                if (mover.Id != timeline.ProducerId)
                    continue;

                MovementPhase phase = mover.Phases[mover.CurrentPhaseIndex];
                mover.ReplaceDuration(phase.Duration);
                
                float time = Mathf.Clamp01(timeline.NormalizedTime);
                
                Vector3 offset = phase.Curve != null
                    ? phase.Curve.Evaluate(time) * phase.Offset
                    : Vector3.Lerp(Vector3.zero, phase.Offset, time);

                mover.ReplaceWorldPosition(mover.PhaseStartPosition + offset);

                if (time < 1f)
                    continue;

                timeline.ReplaceNormalizedTime(0f);
                mover.ReplaceCurrentPhaseIndex(mover.CurrentPhaseIndex + 1);
                mover.ReplacePhaseStartPosition(mover.WorldPosition);

                if (mover.CurrentPhaseIndex < mover.Phases.Count)
                    continue;

                mover.isDestinationReached = true;
            }
        }
    }
}
