using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.Combats.Systems
{
    public class SpawnEffectsFromAbilitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _abilities;
        private readonly IEffectFactory _effectFactory;

        public SpawnEffectsFromAbilitySystem(
            GameContext game,
            IEffectFactory effectFactory)
        {
            _effectFactory = effectFactory;

            _abilities = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.EffectSetups,
                        GameMatcher.EffectResolutionPhase)
                    .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities)
            {
                foreach (EffectSetup effect in ability.EffectSetups)
                    _effectFactory.CreateEffect(effect, ability.ProducerId, ability.TargetId);

                ability.isProcessed = true;
            }
        }
    }
}
