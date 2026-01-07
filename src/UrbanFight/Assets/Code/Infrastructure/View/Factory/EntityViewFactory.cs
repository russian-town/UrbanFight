using Code.Infrastructure.Loading;
using Code.Infrastructure.Services.Assets;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View.Factory
{
    public class EntityViewFactory : IEntityViewFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
        private readonly ISceneLoader _sceneLoader;
        private readonly Vector3 _farAway = new(-999, 999, 0);

        public EntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator, ISceneLoader sceneLoader)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
            _sceneLoader = sceneLoader;
        }

        public EntityBehaviour CreateViewForEntity(GameEntity entity)
        {
            EntityBehaviour viewPrefab = _assetProvider.LoadAsset<EntityBehaviour>(entity.ViewPath);

            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                viewPrefab,
                position: _farAway,
                Quaternion.identity,
                parentTransform: null);

            MoveViewToScene(view);

            view.SetEntity(entity);
            return view;
        }

        public EntityBehaviour CreateViewForEntityFromPrefabWithParent(GameEntity entity)
        {
            EntityBehaviour viewPrefab = _assetProvider.LoadAsset<EntityBehaviour>(entity.ViewPath);

            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                viewPrefab,
                position: Vector2.zero,
                Quaternion.identity,
                parentTransform: entity.Parent);

            view.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            view.SetEntity(entity);
            return view;
        }

        public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
        {
            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                entity.ViewPrefab,
                position: _farAway,
                Quaternion.identity,
                parentTransform: null);

            MoveViewToScene(view);

            view.SetEntity(entity);
            return view;
        }

        private void MoveViewToScene(Component view)
        {
            GameObject viewGameObject = view.gameObject;

            viewGameObject.SetActive(false);
            _sceneLoader.MoveObjectToScene(viewGameObject);
            viewGameObject.SetActive(true);
        }
    }
}
