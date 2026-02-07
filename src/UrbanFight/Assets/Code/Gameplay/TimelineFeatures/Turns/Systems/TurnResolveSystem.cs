using Code.Gameplay.TimelineFeatures.Turns.Services;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.TimelineFeatures.Turns.Systems
{
    public class TurnResolveSystem : IExecuteSystem
    {
        private readonly ITurnService _turnService;
        private readonly IGroup<GameEntity> _fighters;
        private readonly IGroup<GameEntity> _timelines;
        private readonly IGroup<GameEntity> _effects;

        public TurnResolveSystem(GameContext game, ITurnService turnService)
        {
            _turnService = turnService;

            _fighters = game.GetGroup(
                GameMatcher.AllOf(GameMatcher.Id, GameMatcher.WorldPosition, GameMatcher.StartPosition));

            _timelines = game.GetGroup(
                GameMatcher.AllOf(GameMatcher.Timeline, GameMatcher.ActiveTimeline)
                    .NoneOf(GameMatcher.Destructed));

            _effects = game.GetGroup(
                GameMatcher.AllOf(GameMatcher.Effect)
                    .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            if (_timelines.count > 0)
                return;

            if (_effects.count > 0)
                return;

            foreach (GameEntity fighter in _fighters)
            {
                float distance = Vector3.Distance(fighter.WorldPosition, fighter.StartPosition);
                
                if (distance > 0.01f)
                    return;
            }

            _turnService.EndCurrentTurn();
        }
    }
}
