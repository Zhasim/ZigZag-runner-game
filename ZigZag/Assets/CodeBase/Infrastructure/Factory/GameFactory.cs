using CodeBase.Infrastructure.AssetManagement;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
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