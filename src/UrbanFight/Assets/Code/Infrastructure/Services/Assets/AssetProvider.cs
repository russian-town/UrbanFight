using UnityEngine;

namespace Code.Infrastructure.Services.Assets
{
    public class AssetProvider : IAssetProvider
    {
        public T Load<T>(string path) where T : ScriptableObject => Resources.Load<T>(path);
        public T LoadAsset<T>(object viewPath) => throw new System.NotImplementedException();
    }
}
