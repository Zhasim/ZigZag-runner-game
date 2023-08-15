using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.Progress.Registration;
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

        public GameObject CreatePlayer(Vector3 at)
        {
            GameObject prefab = _resourceLoader.Load(AssetPath.PLAYER);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, at, Quaternion.identity, null);

            return instance;
        }

        public GameObject CreateInitPlatform(Vector3 at)
        {
            GameObject prefab = _resourceLoader.Load(AssetPath.INIT_PLATFORM);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, at, Quaternion.identity, null);

            return instance;
        }
        public GameObject CreateDiamond(Vector3 at)
        {
            GameObject prefab = _resourceLoader.Load(AssetPath.DIAMOND);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, at, Quaternion.identity, null);

            return instance;
        }
        public GameObject CreateBlock(Vector3 at)
        {
            GameObject prefab = _resourceLoader.Load(AssetPath.BLOCK);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, at, Quaternion.identity, null);

            return instance;
        }
    }
}