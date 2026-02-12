using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.Combats.Systems
{
    public class ApplySkipTurnSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _changes;

        public ApplySkipTurnSystem(GameContext game)
        {
            _changes = game.GetGroup(GameMatcher.SkipNextTurn);
        }

        public void Execute()
        {
            foreach (GameEntity change in _changes)
            {
                GameEntity target = change.Target();
                target.AddSkipNextTurn(change.SkipNextTurn);
            }
        }
    }
}
