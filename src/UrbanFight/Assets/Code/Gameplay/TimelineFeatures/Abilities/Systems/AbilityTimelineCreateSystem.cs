using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Fighter;
using Code.Gameplay.TimelineFeatures.Timelines.Factories;
using Code.Infrastructure.Services.StaticData;
using Entitas;

namespace Code.Gameplay.TimelineFeatures.Abilities.Systems
{
    public class AbilityTimelineCreateSystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly ITimelineFactory _timelineFactory;
        private readonly IGroup<GameEntity> _intents;

        public AbilityTimelineCreateSystem(
            GameContext game,
            IStaticDataService staticDataService,
            ITimelineFactory timelineFactory)
        {
            _staticDataService = staticDataService;
            _timelineFactory = timelineFactory;

            _intents = game.GetGroup(
                GameMatcher.AllOf(
                        GameMatcher.AbilityIntent,
                        GameMatcher.ProducerId,
                        GameMatcher.TargetId,
                        GameMatcher.AbilityTypeId)
                    .NoneOf(GameMatcher.Processed));
        }

        public void Execute()
        {
            foreach (GameEntity intent in _intents)
            {
                intent.isProcessed = true;

                AbilityConfig config = _staticDataService
                    .GetAbilityConfigByFighterTypeId(
                        FighterTypeId.Ganz, intent.AbilityTypeId);

                _timelineFactory.CreateTimeline(config, intent.ProducerId, intent.TargetId);
            }
        }
    }
}
