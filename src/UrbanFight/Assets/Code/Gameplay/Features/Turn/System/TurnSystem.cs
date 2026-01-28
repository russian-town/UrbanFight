using System.Collections.Generic;
using Code.Common.Extensions;
using Entitas;

namespace Code.Gameplay.Features.Turn.System
{
    public class TurnSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _turns;

        public TurnSystem(GameContext game)
        {
            _game = game;

            _turns = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.TurnQueue,
                    GameMatcher.TurnState));
        }

        public void Execute()
        {
            foreach (GameEntity turn in _turns)
            {
                Queue<GameEntity> queue = turn.TurnQueue;

                switch (turn.TurnState)
                {
                    case TurnState.StartTurn:
                        if (queue.Count == 0)
                            return;

                        queue.Dequeue().With(x => x.isTurnOwner = true);
                        turn.ReplaceTurnState(TurnState.Action);

                        break;

                    case TurnState.Action:
                        if (!AnyEntityHasAttackIntent())
                            turn.ReplaceTurnState(TurnState.EndTurn);

                        break;

                    case TurnState.EndTurn:
                        GameEntity owner = GetTurnOwner();

                        if (owner != null)
                        {
                            owner.isTurnOwner = false;
                            queue.Enqueue(owner);
                        }

                        turn.ReplaceTurnState(TurnState.StartTurn);
                        break;
                }
            }
        }

        private bool AnyEntityHasAttackIntent() =>
            _game.GetGroup(GameMatcher.AttackIntent).count > 0;

        private GameEntity GetTurnOwner()
        {
            IGroup<GameEntity> group = _game.GetGroup(GameMatcher.TurnOwner);

            return group.count > 0
                ? group.GetSingleEntity()
                : null;
        }
    }
}
