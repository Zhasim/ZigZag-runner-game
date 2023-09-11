using CodeBase.Infrastructure.ResourceLoad;
using CodeBase.Infrastructure.Services.Ads;
using CodeBase.Infrastructure.Services.Progress.Service;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Windows;
using UnityEngine;
using Zenject;

namespace CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IResourceLoader _resourceLoader;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progressService;
        private readonly IAdsService _adsService;
        private readonly IInstantiator _instantiator;

        private UIRoot _uiRoot;

        public UIFactory(IResourceLoader resourceLoader, 
            IStaticDataService staticData,
            IProgressService progressService,
            IAdsService adsService, 
            IInstantiator instantiator)
        {
            _resourceLoader = resourceLoader;
            _staticData = staticData;
            _progressService = progressService;
            _adsService = adsService;
            _instantiator = instantiator;
        }

        public void CreateLoseScreen()
        {
        }

        public void CreatePauseScreen()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Pause);
            PauseWindow window = _instantiator.InstantiatePrefabForComponent<PauseWindow>(config.Prefab, _uiRoot.PopLayer);
            window.Construct(_progressService);
        }

        public void CreateSettingsScreen()
        {
            
        }

        public void CreateLeaveScreen()
        {
            
        }

        public void CreateRankingScreen()
        {
            
        }

        public void CreateUIRoot()
        {
            Transform container = new GameObject("UI").transform;
            
            GameObject prefab = _resourceLoader.Load(ResourcePath.UIRoot);
            GameObject instance = _instantiator.InstantiatePrefab(prefab, container);
            _uiRoot = instance.GetComponent<UIRoot>();
        }
    }
}