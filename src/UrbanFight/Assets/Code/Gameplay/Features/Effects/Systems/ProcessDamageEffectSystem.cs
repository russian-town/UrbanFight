using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class ProcessDamageEffectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;

        public ProcessDamageEffectSystem(GameContext game)
        {
            _effects = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.DamageEffect,
                        GameMatcher.EffectValue,
                        GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity effect in _effects)
            {
                float damage = effect.EffectValue;
                GameEntity target = effect.Target();

                target.ReplaceCurrentHealth(target.CurrentHealth - damage);
                effect.isProcessed = true;

                if (target.isDead)
                    continue;

                target.ReplaceCurrentHealth(target.CurrentHealth - effect.EffectValue);
            }
        }
    }
}
