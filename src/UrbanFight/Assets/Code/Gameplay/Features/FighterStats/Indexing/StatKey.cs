namespace Code.Gameplay.Features.FighterStats.Indexing
{
    public struct StatKey
    {
        public readonly int TargetId;
        public readonly StatTypeId Stat;

        public StatKey(int targetId, StatTypeId stat)
        {
            TargetId = targetId;
            Stat = stat;
        }
    }
}
