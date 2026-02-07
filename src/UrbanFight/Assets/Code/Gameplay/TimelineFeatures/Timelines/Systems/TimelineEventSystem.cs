using Entitas;

namespace Code.Gameplay.TimelineFeatures.Timelines.Systems
{
    public class TimelineEventSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _timelines;

        public TimelineEventSystem(GameContext game)
        {
            _game = game;

            _timelines = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Timeline,
                    GameMatcher.AttackTrack,
                    GameMatcher.TimelineTime,
                    GameMatcher.TimelineDuration,
                    GameMatcher.HitStartTime,
                    GameMatcher.HitEndTime));
        }

        public void Execute()
        {
            foreach (GameEntity timeline in _timelines)
            {
                float prev = timeline.PreviousNormalizedTime;
                float now = timeline.TimelineTime / timeline.TimelineDuration;
                float start = timeline.HitStartTime;
                float end   = timeline.HitEndTime;

                bool entered = prev < start && now >= start;

                if (entered)
                {
                    GameEntity effect = _game.CreateEntity();

                    effect.isDamageEffect = true;
                    effect.AddProducerId(timeline.TimelineOwnerId);
                    effect.AddTargetId(timeline.TimelineTargetId);
                    effect.AddEffectValue(timeline.DamagePerCast);
                }

                timeline.ReplacePreviousNormalizedTime(now);
            }
        }
    }

}
