using UnityEngine;

namespace Code.Infrastructure.Services.Level
{
    public interface ILevelDataProvider
    {
        Transform RightSocket { get; set; }
        Transform LeftSocket { get; set; }
        RectTransform UIRoot { get; set; }
        RectTransform LeftHealthBarSocket { get; set; }
        RectTransform RightHealthBarSocket { get; set; }
        RectTransform AbilityLeftPlaceHolder { get; set; }
        RectTransform AbilityRightPlaceHolder { get; set; }
    }
}
