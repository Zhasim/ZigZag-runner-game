using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.Pool;
using CodeBase.Infrastructure.Services.RegistrationService;
using CodeBase.Logic.TileGeneration;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IRegistrationService _registrationService;
        private readonly IPoolService _poolService;

        public GameFactory(IAssetProvider assetProvider, IRegistrationService registrationService, IPoolService poolService)
        {
            _assetProvider = assetProvider;
            _registrationService = registrationService;
            _poolService = poolService;
        }

        public GameObject CreatePlayer() => 
            _assetProvider.Instantiate(AssetPath.PLAYER);

        public GameObject CreateInitPlatform() => 
            _assetProvider.Instantiate(AssetPath.INIT_PLATFORM);

        public GameObject CreateDiamond() => 
            _assetProvider.Instantiate(AssetPath.DIAMOND);

        public GameObject CreateBlock() => 
            _assetProvider.Instantiate(AssetPath.BLOCK);
        
        public GameObject CreateTileGenerator()
        {
            GameObject tileGenerator = _assetProvider.Instantiate(AssetPath.TILE_GENERATOR);
            tileGenerator.GetComponent<TileGenerator>().Construct(_poolService);
            return tileGenerator;
        }

        public void CreateBlocksPool()
        {
            for (int i = 0; i < Constants.BLOCKS_POOL_COUNT; i++)
            {
                GameObject block = CreateBlock();
                
                _registrationService.RegisterWatchers(block);
                _poolService.BlocksPool.Add(block);
                
                block.gameObject.SetActive(false);
            }
        }
        public void CreateDiamondsPool()
        {
            for (int i = 0; i < Constants.DIAMONDS_POOL_COUNT; i++)
            {
                GameObject diamond = CreateDiamond();
                
                _registrationService.RegisterWatchers(diamond);
                _poolService.DiamondsPool.Add(diamond);
                
                diamond.gameObject.SetActive(false);
            }
        }
    }
}