using Entitas;

namespace Code.Gameplay.Interrupt.Systems
{
    public class InterruptTurnSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _interrupts;
        private readonly GameContext _game;

        public InterruptTurnSystem(GameContext game)
        {
            _game = game;

            _interrupts = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.TargetId,
                    GameMatcher.InterruptTypeId));
        }

        public void Execute()
        {
            foreach (GameEntity interrupt in _interrupts)
            {
                GameEntity target = _game.GetEntityWithId(interrupt.TargetId);

                if (target == null)
                {
                    interrupt.Destroy();
                    continue;
                }

                switch (interrupt.InterruptTypeId)
                {
                    case InterruptTypeId.EndTurn:
                        HandleEndTurn(target);
                        break;

                    case InterruptTypeId.SkipNextTurn:
                        target.isSkipNextTurn = true;
                        break;
                }

                interrupt.Destroy();
            }
        }

        private static void HandleEndTurn(GameEntity target)
        {
            if (!target.isTurnOwner)
                return;

            target.isForceEndTurn = true;
        }
    }
}
