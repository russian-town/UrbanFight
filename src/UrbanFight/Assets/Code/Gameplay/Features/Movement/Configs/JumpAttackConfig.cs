using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Configs
{
    [CreateAssetMenu(menuName = "UrbanFight/Movement/Configs", fileName = "MovementConfig", order = 59)]
    public class JumpAttackConfig : ScriptableObject
    {
        public List<MovementPhase> Phases;
    }
}
