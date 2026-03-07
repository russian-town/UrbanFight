using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Lifetime.Behaviours
{
    public class HealthBar : MonoBehaviour
    {
        public Image Fill;
        public TextMeshProUGUI HP_Text;

        public void UpdateHealth(float currentHealth, float maxHealth)
        {
            Fill.fillAmount = currentHealth / maxHealth;
            HP_Text.text = $"{currentHealth}/{maxHealth}";
        }
    }
}
