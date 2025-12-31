using UnityEngine;

namespace Code.Infrastructure.Services.Level
{
    public interface ILevelDataProvider
    {
        Transform RightSocket { get; set; }
        Transform LeftSocket { get; set; }
    }
}
