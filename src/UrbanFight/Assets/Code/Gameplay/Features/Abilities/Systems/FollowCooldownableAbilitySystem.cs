using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
    public class FollowCooldownableAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;

        public FollowCooldownableAbilitySystem(GameContext game)
        {
            _abilities = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Ability,
                    GameMatcher.CooldownUp,
                    GameMatcher.Casted));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities)
            {
                
            }
        }
    }
}
