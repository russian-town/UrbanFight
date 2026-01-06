using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class ProcessCounterattackEffectSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _effects;

        public ProcessCounterattackEffectSystem(GameContext game)
        {
            _effects = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.CounterattackEffect,
                        GameMatcher.EffectValue,
                        GameMatcher.TargetId));
        }

        public void Execute()
        {
            foreach (GameEntity effect in _effects)
            {
                GameEntity target = effect.Target();

                effect.isProcessed = true;

                if (target.isDead)
                    continue;

                target.ReplaceCurrentHealth(target.CurrentHealth - effect.EffectValue);

                if (target.hasFighterAnimator)
                    target.FighterAnimator.PlayKnock();
            }
        }
    }
}
