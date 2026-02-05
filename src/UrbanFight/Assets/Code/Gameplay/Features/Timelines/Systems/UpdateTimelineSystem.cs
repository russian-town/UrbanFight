using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Timelines.Systems
{
    public class UpdateTimelineSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _timelines;
        private readonly IGroup<GameEntity> _durationsOwners;
        private readonly List<GameEntity> _buffer = new(16);

        public UpdateTimelineSystem(GameContext game, ITimeService time)
        {
            _time = time;

            _timelines = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Timeline,
                    GameMatcher.NormalizedTime,
                    GameMatcher.Started));

            _durationsOwners = game.GetGroup(GameMatcher.AllOf(GameMatcher.Duration));
        }

        public void Execute()
        {
            foreach (GameEntity timeline in _timelines.GetEntities(_buffer))
            {
                float value = timeline.NormalizedTime + _time.DeltaTime / GetDuration();
                timeline.ReplaceNormalizedTime(Mathf.Clamp01(value));
            }
        }

        private float GetDuration()
        {
            if (_durationsOwners.count == 0)
                return 1f;

            foreach (GameEntity durationOwner in _durationsOwners)
                return durationOwner.Duration;

            return 1f;
        }
    }
}
