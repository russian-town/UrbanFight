using UnityEngine;

namespace Code.Infrastructure.Services.Assets
{
    public interface IAssetProvider
    {
        T Load<T>(string path) where T : ScriptableObject;
        T LoadAsset<T>(string path) where T : Component;
        T[] LoadAll<T>(string path) where T : ScriptableObject;
    }
}
