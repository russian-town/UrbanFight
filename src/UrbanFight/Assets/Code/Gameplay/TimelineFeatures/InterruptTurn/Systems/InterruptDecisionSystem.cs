using Entitas;

namespace Code.Gameplay.TimelineFeatures.InterruptTurn.Systems
{
    public class InterruptDecisionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _effects;

        public InterruptDecisionSystem(GameContext game)
        {
            _game = game;

            _effects = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.CausesInterrupt,
                        GameMatcher.TargetId)
                    .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (GameEntity effect in _effects)
            {
                effect.isProcessed = true;

                GameEntity request = _game.CreateEntity();
                request.isInterruptRequest = true;
                request.AddInterruptTargetId(effect.TargetId);
                request.AddInterruptType(effect.InterruptType);
            }
        }
    }
}
