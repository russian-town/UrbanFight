using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Lifetime.Behaviours
{
    public class HealthBar : MonoBehaviour
    {
        public Image Fill;

        public void UpdateHealth(float currentHealth, float maxHealth) =>
            Fill.fillAmount = currentHealth / maxHealth;
    }
}
