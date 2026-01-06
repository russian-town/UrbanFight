using UnityEngine;

namespace Code.Infrastructure.Services.Level
{
    public class LevelDataProvider : ILevelDataProvider
    {
        public Transform RightSocket { get; set; }
        public Transform LeftSocket { get; set; }
        public RectTransform UIRoot { get; set; }
    }
}
