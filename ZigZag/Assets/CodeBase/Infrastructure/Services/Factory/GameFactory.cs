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

        public GameObject CreatePlayer(Vector3 at)
        {
            GameObject prefab = _resourceLoader.Load(ResourcePath.PLAYER);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, at, Quaternion.identity, null);

            return instance;
        }
        public GameObject CreatePlayer()
        {
            GameObject prefab = _resourceLoader.Load(ResourcePath.PLAYER);
            GameObject instance = _instantiator.InstantiatePrefab(prefab);
            _registrationService.RegisterWatchers(instance);

            return instance;
        }

        public GameObject CreateInitPlatform(Vector3 at)
        {
            GameObject prefab = _resourceLoader.Load(ResourcePath.INIT_PLATFORM);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, at, Quaternion.identity, null);

            return instance;
        }
        public GameObject CreateDiamond(Vector3 at)
        {
            GameObject prefab = _resourceLoader.Load(ResourcePath.DIAMOND);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, at, Quaternion.identity, null);

            return instance;
        }
        public GameObject CreateBlock(Vector3 at)
        {
            GameObject prefab = _resourceLoader.Load(ResourcePath.BLOCK);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, at, Quaternion.identity, null);

            return instance;
        }
    }
}