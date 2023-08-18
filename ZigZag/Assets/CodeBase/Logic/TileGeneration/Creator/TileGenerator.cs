using CodeBase.Entity.Blocks;
using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Pool.Pools;
using CodeBase.Infrastructure.Services.Randomizer;
using UnityEngine;

namespace CodeBase.Logic.TileGeneration.Creator
{
    public class TileGenerator : ITileGenerator
    {
        private const float TileWidth = 4f;

        private readonly IBlocksPool _blocksPool;
        private readonly IDiamondsPool _diamondsPool;
        private readonly IRandomService _randomService;

        private Vector3 _lastBlockPosition;
        private Vector3 _highDiamondPosition;
        private Vector3 _lastPlayerPosition;

        private Transform _playerTransform;

        public TileGenerator(IBlocksPool blocksPool,
            IDiamondsPool diamondsPool,
            IRandomService randomService)
        {
            _blocksPool = blocksPool;
            _diamondsPool = diamondsPool;
            _randomService = randomService;
        }

        public void Init(Transform playerTransform)
        {
            _playerTransform = playerTransform;

            _lastPlayerPosition = _playerTransform.position;
            _lastBlockPosition = Vector3.zero;
            _highDiamondPosition = Vector3.up * 6f;

            InitPools();
            InitSpawn();
        }
        
        public void HandlePlayerInput()
        {
            Vector3 position = _playerTransform.position;
            float distanceTraveled = Vector3.Distance(position, _lastPlayerPosition);
            _lastPlayerPosition = position;
            
            if (distanceTraveled >= TileWidth)
            {
                int tilesToGenerate = Mathf.FloorToInt(distanceTraveled / TileWidth) + 1;
                for (int i = 0; i < tilesToGenerate; i++)
                    SpawnTile();
            }
        }

        private void InitPools()
        {
            _blocksPool.Init();
            _diamondsPool.Init();
        }

        private void InitSpawn()
        {
            for (int i = 0; i < 40; i++)
                SpawnTile();
        }

        private void SpawnTile()
        {
            Vector3 currentPosition = CalculateNextBlockPosition();
            Block currentBlock = _blocksPool.RentBlock();

            currentBlock.transform.position = currentPosition;
            _lastBlockPosition = currentPosition;

            SpawnDiamond();
        }

        private Vector3 CalculateNextBlockPosition()
        {
            int randomValue = _randomService.Next(0, 2);
            Vector3 currentPosition = _lastBlockPosition;

            if (randomValue == 0)
                currentPosition.x += TileWidth;
            else
                currentPosition.z -= TileWidth;

            return currentPosition;
        }

        private void SpawnDiamond()
        {
            int chanceToDiamond = _randomService.Next(0, 4);
            if (chanceToDiamond == 0)
            {
                Diamond diamond = _diamondsPool.RentDiamond();
                diamond.transform.position = _lastBlockPosition + _highDiamondPosition;
            }
        }
    }
}