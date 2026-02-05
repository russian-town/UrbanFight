using Code.Gameplay.Features.Movement.Configs;
using Entitas;

namespace Code.Gameplay.Features.AbilityAnimation.Jump
{
    public class UpdateJumpAnimationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _fighters;
        private readonly IGroup<GameEntity> _timelines;
        private readonly IGroup<GameEntity> _jumpPhases;

        public UpdateJumpAnimationSystem(GameContext game)
        {
            _fighters = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Fighter,
                        GameMatcher.Phases,
                        GameMatcher.CurrentPhaseIndex,
                        GameMatcher.FighterAnimator,
                        GameMatcher.Id));

            _timelines = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Timeline,
                        GameMatcher.Started,
                        GameMatcher.NormalizedTime,
                        GameMatcher.ProducerId));
        }

        public void Execute()
        {
            foreach (GameEntity timeline in _timelines)
            foreach (GameEntity fighter in _fighters)
            {
                if (fighter.Id != timeline.ProducerId)
                    continue;

                if (fighter.CurrentPhaseIndex >= fighter.Phases.Count)
                    continue;

                MovementPhase phase = fighter.Phases[fighter.CurrentPhaseIndex];

                switch (phase.Type)
                {
                    case MovementPhaseType.JumpUp:
                        fighter.FighterAnimator.PlayJumpUp(timeline.NormalizedTime);
                        break;
                    case MovementPhaseType.MoveForwardAir:
                        fighter.FighterAnimator.PlayMoveForwardAir(timeline.NormalizedTime);
                        break;
                    case MovementPhaseType.SlamDown:
                        fighter.FighterAnimator.PlaySlamDown(timeline.NormalizedTime);
                        break;
                }
            }
        }
    }
}
