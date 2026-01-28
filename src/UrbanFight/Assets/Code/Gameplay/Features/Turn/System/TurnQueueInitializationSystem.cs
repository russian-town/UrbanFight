using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Turn.Factories;
using Entitas;

namespace Code.Gameplay.Features.Turn.System
{
    public sealed class TurnQueueInitializationSystem : IInitializeSystem
    {
        private readonly ITurnFactory _turnFactory;
        private readonly IGroup<GameEntity> _fighters;

        public TurnQueueInitializationSystem(GameContext game, ITurnFactory turnFactory)
        {
            _turnFactory = turnFactory;
            
            _fighters = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.Initiative));
        }

        public void Initialize()
        {
            List<GameEntity> sortedFighters = _fighters
                .GetEntities()
                .OrderByDescending(x => x.Initiative)
                .ToList();

            _turnFactory.CreateTurn(sortedFighters);
        }
    }
}
