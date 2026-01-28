using System.Collections.Generic;

namespace Code.Gameplay.Features.Turn.Factories
{
    public interface ITurnFactory
    {
        GameEntity CreateTurn(IEnumerable<GameEntity> sorted);
    }
}
