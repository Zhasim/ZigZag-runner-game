using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.Registration;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IRegistrationService _registrationService;
        public GameFactory(IAssetProvider assetProvider, 
            IRegistrationService registrationService)
        {
            _assetProvider = assetProvider;
            _registrationService = registrationService;
        }

        public GameObject CreatePlayer() => 
            _assetProvider.Instantiate(AssetPath.PLAYER);

        public GameObject CreateInitPlatform() => 
            _assetProvider.Instantiate(AssetPath.INIT_PLATFORM);

        public GameObject CreateDiamond() => 
            _assetProvider.Instantiate(AssetPath.DIAMOND);

        public GameObject CreateBlock() => 
            _assetProvider.Instantiate(AssetPath.BLOCK);
    }
}