using Code.Gameplay.Features.Abilities.Configs;
using TMPro;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Behaviours
{
    public class AbilityItem : MonoBehaviour
    {
        public TextMeshProUGUI Debug;
        
        public void Setup(AbilityConfig config)
        {
            Debug.text = config.DebugText;
        }
    }
}
