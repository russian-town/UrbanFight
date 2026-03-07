using Code.Gameplay.Features.Abilities.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Abilities.Behaviours
{
    public class AbilityItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image Icon;
        public Image DesctiptionImage;
        public TextMeshProUGUI Desctiption;
        public TextMeshProUGUI Name;

        public void Setup(AbilityConfig config)
        {
            Icon.sprite = config.Icon;
            Desctiption.text = config.Desctiption;
            Name.text = config.Name;
        }

        public void OnPointerEnter(PointerEventData eventData) =>
            DesctiptionImage.gameObject.SetActive(true);

        public void OnPointerExit(PointerEventData eventData) =>
            DesctiptionImage.gameObject.SetActive(false);
    }
}
