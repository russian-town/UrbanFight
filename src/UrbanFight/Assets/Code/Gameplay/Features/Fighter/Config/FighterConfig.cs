using System.Collections.Generic;
using Code.Gameplay.FighterStats.Configs;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Fighter.Config
{
    [CreateAssetMenu(menuName = "UrbanFight/Fighter/Config", fileName = "FighterConfig", order = 59)]
    public class FighterConfig : ScriptableObject
    {
        public FighterTypeId TypeId;
        public List<StatByTypeId> FighterStats;
        public EntityBehaviour EntityTemplate;
    }
}
