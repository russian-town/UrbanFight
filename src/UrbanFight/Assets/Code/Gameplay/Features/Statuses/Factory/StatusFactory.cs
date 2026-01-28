using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Services.Identifiers;

namespace Code.Gameplay.Features.Statuses.Factory
{
    public class StatusFactory : IStatusFactory
    {
        private readonly IIdentifierService _identifiers;

        public StatusFactory(IIdentifierService identifiers) => _identifiers = identifiers;

        public GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId)
        {
            GameEntity status = CreateEntity.Empty()
                    .AddId(_identifiers.Next())
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                    .With(x => x.isStatus = true)
                    .With(x => x.AddDuration(setup.Duration), when: setup.Duration > 0)
                    .With(x => x.AddTimeLeft(setup.Duration), when: setup.Duration > 0)
                    .With(x => x.AddPeriod(setup.Period), when: setup.Period > 0)
                    .With(x => x.AddTimeSinceLastTick(0), when: setup.Period > 0)
                ;

            return setup.StatusTypeId switch
            {
                StatusTypeId.Block => CreateBlockStatus(status),
                StatusTypeId.Counterattack => CreateCounterattackStatus(status),
                StatusTypeId.Dodge => CreateDodgeStatus(status),
                _ => throw new ArgumentException($"Status with id {setup.StatusTypeId} not found.")
            };
        }

        private GameEntity CreateBlockStatus(GameEntity status) =>
            status.With(x => x.isBlock = true);

        private GameEntity CreateCounterattackStatus(GameEntity status) =>
            status.With(x => x.isCounterattack = true);

        private GameEntity CreateDodgeStatus(GameEntity status)
        {
            return status;
        }
    }
}
