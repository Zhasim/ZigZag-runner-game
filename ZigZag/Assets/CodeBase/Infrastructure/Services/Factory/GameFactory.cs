using CodeBase.Infrastructure.ResourceLoad;
using CodeBase.Infrastructure.Services.Progress.Registration;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IResourceLoader _resourceLoader;
        private readonly IInstantiator _instantiator;
        private readonly IRegistrationService _registrationService;

        public GameFactory(IResourceLoader resourceLoader,
            IInstantiator instantiator,
            IRegistrationService registrationService)
        {
            _resourceLoader = resourceLoader;
            _instantiator = instantiator;
            _registrationService = registrationService;
        }

        public GameObject CreatePlayer(Vector3 at, Transform container)
        {
            GameObject prefab = _resourceLoader.Load(ResourcePath.PLAYER);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, at, Quaternion.identity, container);

            return instance;
        }

        public GameObject CreateInitPoint(Transform container)
        {
            GameObject prefab = _resourceLoader.Load(ResourcePath.INIT_POINT);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, container);
            
            return instance;
        }

        public GameObject CreateInitPlatform(Transform parent)
        {
            GameObject prefab = _resourceLoader.Load(ResourcePath.INIT_PLATFORM);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, parent);

            return instance;
        }
    }
}