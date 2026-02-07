namespace Code.Gameplay.TimelineFeatures.Turns.Services
{
    public interface ITurnService
    {
        int CurrentActor { get; }
        void StartNextTurn();
        void EndCurrentTurn();
        bool CanAct(GameEntity fighter);
    }
}
