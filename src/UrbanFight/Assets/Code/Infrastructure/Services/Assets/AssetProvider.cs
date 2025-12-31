using UnityEngine;

namespace Code.Infrastructure.Services.Assets
{
    public class AssetProvider : IAssetProvider
    {
        private IAssetProvider _assetProviderImplementation;
        public T Load<T>(string path) where T : ScriptableObject => Resources.Load<T>(path);
        public T LoadAsset<T>(string path) where T : Component => Resources.Load<T>(path);
        public T[] LoadAll<T>(string path) where T : ScriptableObject => Resources.LoadAll<T>(path);
    }
}
