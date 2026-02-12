using System.Collections.Generic;
using Code.Gameplay.Features.Combats;
using Code.Gameplay.Features.Fighter;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
    [CreateAssetMenu(menuName = "UrbanFight/Ability/Config", fileName = "AbilityConfig", order = 59)]
    public class AbilityConfig : ScriptableObject
    {
        public AbilityTypeId TypeId;
        public FighterTypeId FighterTypeId;
        public BattleTypeId BattleTypeId;
        [Range(0f, 1f)] public float Chanse;
        public List<AbilityLevel> Levels;

        public string AbilityName;
        public float ApproachSpeed;
        public float WindUpTime;
        public float Damage;
        public float ReactionWindowStart;
        public float ReactionWindowEnd;
        public TelegraphTypeId TelegraphTypeId;
        public bool SkipNextTurnOnHit;
        public AbilityConfig[] FollowUpAbilities;
        [Range(0f, 1f)] public float FollowUpChance;
        public float Efficiency;
    }
}
