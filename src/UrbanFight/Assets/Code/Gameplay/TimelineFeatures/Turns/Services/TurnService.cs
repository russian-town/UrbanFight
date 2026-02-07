using System.Collections.Generic;

namespace Code.Gameplay.TimelineFeatures.Turns.Services
{
    public class TurnService : ITurnService
    {
        private readonly Queue<int> _turnOrder = new();
        
        private int _currentId;

        public int CurrentActor => _currentId;

        public void StartNextTurn()
        {
            if (_turnOrder.Count == 0) return;

            _currentId = _turnOrder.Dequeue();
            _turnOrder.Enqueue(_currentId);
        }

        public void EndCurrentTurn() => StartNextTurn();

        public bool CanAct(GameEntity fighter) => fighter.Id == _currentId;
    }
}
