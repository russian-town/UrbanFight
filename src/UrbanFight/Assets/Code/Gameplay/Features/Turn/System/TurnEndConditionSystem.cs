using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Turn.System
{
    public sealed class TurnEndConditionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _turns;
        private readonly IGroup<GameEntity> _castingAbilities;
        private readonly IGroup<GameEntity> _hitMoments;
        private readonly IGroup<GameEntity> _turnOwners;

        public TurnEndConditionSystem(GameContext game)
        {
            _turns = game.GetGroup(GameMatcher.TurnState);
            _castingAbilities = game.GetGroup(GameMatcher.AbilityCasting);
            _hitMoments = game.GetGroup(GameMatcher.AbilityHitMoment);
            _turnOwners = game.GetGroup(GameMatcher.TurnOwner);
        }

        public void Execute()
        {
            GameEntity turn = _turns.GetSingleEntity();
            
            if (turn.TurnState != TurnState.Action)
                return;

            GameEntity owner = _turnOwners.GetSingleEntity();

            if (owner is { isForceEndTurn: true, })
            {
                Debug.Log("[TURN END BY INTERRUPT]");
                turn.ReplaceTurnState(TurnState.EndTurn);
                return;
            }

            if (_castingAbilities.count > 0)
                return;

            if (_hitMoments.count > 0)
                return;

            Debug.Log("[TURN END NORMAL]");
            turn.ReplaceTurnState(TurnState.EndTurn);
        }
    }
}
