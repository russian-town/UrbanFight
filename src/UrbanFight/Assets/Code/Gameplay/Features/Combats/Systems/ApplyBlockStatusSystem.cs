using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.FighterStats;
using Code.Gameplay.Features.Statuses;
using Entitas;

namespace Code.Gameplay.Features.Combats.Systems
{
    public class ApplyBlockStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;

        public ApplyBlockStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(
                GameMatcher 
                    .AllOf(
                        GameMatcher.Id,
                        GameMatcher.TargetId,
                        GameMatcher.EffectValue,
                        GameMatcher.Status,
                        GameMatcher.StatusTypeId)
                    .NoneOf(GameMatcher.Affected));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses)
            {
                if (status.StatusTypeId != StatusTypeId.Block)
                    continue;

                CreateEntity.Empty()
                    .AddStatChange(StatTypeId.BaseDamage)
                    .With(x => x.isDamageModifier = true)
                    .AddTargetId(status.TargetId)
                    .AddEffectValue(status.EffectValue)
                    .AddApplierStatusLink(status.Id)
                    ;

                status.isAffected = true;
            }
        }
    }
}
