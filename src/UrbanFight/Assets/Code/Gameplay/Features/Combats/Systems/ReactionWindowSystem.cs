using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Combats.Systems
{
    public class ReactionWindowSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(32);

        public ReactionWindowSystem(GameContext game)
        {
            _abilities = game.GetGroup(
                GameMatcher
                    .AllOf(GameMatcher.TelegraphPhase)
                    .NoneOf(GameMatcher.ReactionWindow));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
                ability.isReactionWindow = true;
        }
    }
}
