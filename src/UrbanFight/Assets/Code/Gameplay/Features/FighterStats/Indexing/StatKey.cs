using Code.Gameplay.Features.FighterStats;

namespace Code.Gameplay.Features.CharacterStats.Indexing
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
