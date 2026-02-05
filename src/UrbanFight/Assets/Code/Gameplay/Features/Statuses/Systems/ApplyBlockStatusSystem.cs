using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class ApplyBlockStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly IGroup<GameEntity> _fighters;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(16);

        public ApplyBlockStatusSystem(GameContext game)
        {
            _statuses = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.Status,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId)
                    .NoneOf(GameMatcher.Applied));

            _fighters = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Fighter,
                    GameMatcher.FighterAnimator,
                    GameMatcher.Id));

            _abilities = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Ability,
                    GameMatcher.ProducerId,
                    GameMatcher.CooldownUp));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses.GetEntities(_buffer))
            foreach (GameEntity fighter in _fighters)
            {
                if (status.ProducerId != fighter.Id)
                    continue;

                foreach (GameEntity ability in _abilities)
                {
                    if (ability.ProducerId != status.TargetId)
                        continue;

                    status.isApplied = true;
                }
            }
        }
    }
}
