using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Infrastructure.Services.Identifiers;

namespace Code.Gameplay.TimelineFeatures.Timelines.Factories
{
    public class TimelineFactory : ITimelineFactory
    {
        private readonly IIdentifierService _identifiers;

        public TimelineFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }
        
        public GameEntity CreateTimeline(AbilityConfig config, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .With(x => x.isTimeline = true)
                .AddTimelineOwnerId(producerId)
                .AddParentAbilityId(config.TypeId)
                .AddTimelineTargetId(targetId)
                .AddTimelineDuration(config.Duration)
                .AddTimelineTime(0f)
                .AddTimelineNormalizedTime(0f)
                .With(x => x.isMovementTrack = true, when: config.HasMovement)
                .With(x => x.AddMovementType(config.MovementType), when: config.HasMovement)
                .With(x => x.AddMoveStartTime(config.MoveStart), when: config.HasMovement)
                .With(x => x.AddMoveEndTime(config.MoveEnd), when: config.HasMovement)
                .With(x => x.isAttackTrack = true, when: config.HasAttack)
                .With(x => x.AddHitStartTime(config.HitStart), when: config.HasAttack)
                .With(x => x.AddHitEndTime(config.HitEnd), when: config.HasAttack)
                .With(x => x.AddDamagePerCast(config.Damage), when: config.HasAttack)
                .With(x => x.isAnimationTrack = true)
                .AddAnimationStateId(config.AnimationState);
        }
    }
}
