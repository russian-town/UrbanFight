using System.Collections.Generic;
using Code.Common.Entity;
using Code.Infrastructure.Services.Identifiers;

namespace Code.Gameplay.Features.Turn.Factories
{
    public class TurnFactory : ITurnFactory
    {
        private readonly IIdentifierService _identifiers;

        public TurnFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateTurn(IEnumerable<GameEntity> sorted)
        {
            return CreateEntity.Empty()
                .AddId(_identifiers.Next())
                .AddTurnQueue(new Queue<GameEntity>(sorted))
                .AddTurnState(TurnState.StartTurn);
        }
    }
}
