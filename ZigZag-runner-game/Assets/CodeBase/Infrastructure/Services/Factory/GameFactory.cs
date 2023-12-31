using CodeBase.Infrastructure.ResourceLoad;
using CodeBase.Infrastructure.Services.Progress.Registration;
using CodeBase.Infrastructure.Services.Progress.Service;
using CodeBase.StaticData;
using CodeBase.UI.Elements;
using CodeBase.UI.Services.Windows;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IResourceLoader _resourceLoader;
        private readonly IInstantiator _instantiator;
        private readonly IProgressService _progressService;
        private readonly IRegistrationService _registrationService;
        private readonly IWindowService _windowService;
        
        public GameFactory(IResourceLoader resourceLoader, 
            IInstantiator instantiator,
            IProgressService progressService,
            IRegistrationService registrationService,
            IWindowService windowService)
        {
            _resourceLoader = resourceLoader;
            _instantiator = instantiator;
            _progressService = progressService;
            _registrationService = registrationService;
            _windowService = windowService;
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

        public GameObject CreateInitPlatform(Transform container)
        {
            GameObject prefab = _resourceLoader.Load(ResourcePath.INIT_PLATFORM);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, container);

            return instance;
        }

        public GameObject CreateHUD(Transform container)
        {
            GameObject prefab = _resourceLoader.Load(ResourcePath.HUD);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, container);
            
            instance.GetComponentInChildren<DiamondsCounter>()
                .Init(_progressService.OverallProgress.WorldData);
            
            foreach (OpenWindowButton openWindowButton in instance.GetComponentsInChildren<OpenWindowButton>())
                openWindowButton.Construct(_windowService);
        
            return instance;
        }
    }
}