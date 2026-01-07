using Entitas;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class UpdateHealthBarSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _fighters;
        private readonly IGroup<GameEntity> _healthBars;

        public UpdateHealthBarSystem(GameContext game)
        {
            _fighters = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Id,
                        GameMatcher.Fighter,
                        GameMatcher.CurrentHealth,
                        GameMatcher.MaxHealth)
                    .NoneOf(GameMatcher.Dead));

            _healthBars = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.HealthBar,
                        GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity fighter in _fighters)
            foreach (GameEntity healthBar in _healthBars)
            {
                if (fighter.Id == healthBar.TargetId)
                    healthBar.HealthBar.UpdateHealth(fighter.CurrentHealth, fighter.MaxHealth);
            }
        }
    }
}
