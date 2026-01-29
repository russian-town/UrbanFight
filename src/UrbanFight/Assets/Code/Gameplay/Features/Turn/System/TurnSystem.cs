using System.Collections.Generic;
using Code.Gameplay.Features.Turn;
using Entitas;
using UnityEngine;

public sealed class TurnSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _turns;
    private readonly IGroup<GameEntity> _turnOwners;

    public TurnSystem(GameContext game)
    {
        _turns = game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.TurnQueue,
                GameMatcher.TurnState));

        _turnOwners = game.GetGroup(GameMatcher.TurnOwner);
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

                    GameEntity current = queue.Dequeue();

                    if (current.isSkipNextTurn)
                    {
                        current.isSkipNextTurn = false;
                        queue.Enqueue(current);

                        Debug.Log($"[TURN SKIPPED] {current.Id}");
                        return;
                    }

                    current.isTurnOwner = true;

                    Debug.Log($"[TURN START] Fighter: {current.Id}");

                    turn.ReplaceTurnState(TurnState.Action);
                    break;

                case TurnState.Action:
                    GameEntity owner = GetTurnOwner();

                    if (owner is { isForceEndTurn: true, })
                    {
                        owner.isForceEndTurn = false;
                        turn.ReplaceTurnState(TurnState.EndTurn);
                        break;
                    }

                    turn.ReplaceTurnState(TurnState.EndTurn);
                    break;

                case TurnState.EndTurn:
                    GameEntity endOwner = GetTurnOwner();

                    if (endOwner != null)
                    {
                        endOwner.isTurnOwner = false;
                        queue.Enqueue(endOwner);
                    }

                    turn.ReplaceTurnState(TurnState.StartTurn);
                    break;
            }
        }
    }

    private GameEntity GetTurnOwner()
    {
        return _turnOwners.count > 0
            ? _turnOwners.GetSingleEntity()
            : null;
    }
}
