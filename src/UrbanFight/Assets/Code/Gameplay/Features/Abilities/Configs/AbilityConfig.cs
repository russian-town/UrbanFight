using System.Collections.Generic;
using Code.Gameplay.Features.Fighter;
using Code.Gameplay.TimelineFeatures.Movements;
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
        public bool Blockable;
        public float Cooldown;
        public float AttackTime;
        public string DebugText;
        public bool IsAnimatedWait;
        
        public AbilityTypeId AbilityId;

        public float Duration;

        public bool HasMovement;
        public MovementTypeId MovementType;
        public float MoveStart;
        public float MoveEnd;

        public bool HasAttack;
        public float HitStart;
        public float HitEnd;
        public float Damage;

        public int AnimationState;
    }
}
