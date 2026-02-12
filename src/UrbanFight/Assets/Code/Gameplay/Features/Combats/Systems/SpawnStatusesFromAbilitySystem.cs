using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.Combats.Systems
{
    public class SpawnStatusesFromAbilitySystem : IExecuteSystem
    {
        private readonly IStatusFactory _statusFactory;
        private readonly IGroup<GameEntity> _abilities;

        public SpawnStatusesFromAbilitySystem(GameContext game, IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;

            _abilities = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.StatusSetups,
                        GameMatcher.StatusResolutionPhase)
                    .NoneOf(GameMatcher.Affected));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities)
            {
                foreach (StatusSetup status in ability.StatusSetups)
                    _statusFactory.CreateStatus(status, ability.ProducerId, ability.TargetId);

                ability.isAffected = true;
            }
        }
    }
}
