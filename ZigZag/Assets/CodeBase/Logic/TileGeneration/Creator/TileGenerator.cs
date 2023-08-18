using CodeBase.Entity.Blocks;
using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Pool.Pools;
using CodeBase.Infrastructure.Services.Randomizer;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.TileGeneration.Creator
{
    public class TileGenerator : ITileGenerator, IInitializable
    {
        private const float BLOCK_STEP = 4f; 
        
        private Vector3 _lastBlockPosition;
        private Vector3 _highDiamondPosition;

        private readonly IBlocksPool _blocksPool;  
        private readonly IDiamondsPool _diamondsPool;
        private readonly IRandomService _randomService;

        public bool IsSpawning { get; set; }

        public TileGenerator(IBlocksPool blocksPool, 
            IDiamondsPool diamondsPool,
            IRandomService randomService)
        {
            _blocksPool = blocksPool;
            _diamondsPool = diamondsPool;
            _randomService = randomService;
        }

        public void Initialize()
        {
            _lastBlockPosition = Vector3.zero;
            _highDiamondPosition = Vector3.up * 6f;
            //IsSpawning = true;
        }

        public void Init()
        {
            InitPools();
            InitSpawn();
        }

        public void CreateTile()  
        {  
            Vector3 currentPosition = CalculateNextBlockPosition(); 
            Block currentBlock = _blocksPool.RentBlock();

            currentBlock.transform.position = currentPosition;  
            _lastBlockPosition = currentPosition;  
            
            CreateDiamond();  
        }

        private void InitPools()  
        {  
            _blocksPool.Init();
            _diamondsPool.Init();
        }

        private void InitSpawn()
        {
            for (int i = 0; i < 20; i++)
                CreateTile();
        }

        private Vector3 CalculateNextBlockPosition()
        {
            int randomValue = _randomService.Next(0, 2);  
            Vector3 currentPosition = _lastBlockPosition;  

            if (randomValue == 0)  
                currentPosition.x += BLOCK_STEP;  
            else  
                currentPosition.z -= BLOCK_STEP;  

            return currentPosition;
        }
        
        private void CreateDiamond()  
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