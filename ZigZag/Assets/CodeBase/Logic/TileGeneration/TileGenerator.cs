using System.Collections;
using CodeBase.Entity;
using CodeBase.Entity.Blocks;
using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Foundation.CoroutineAccess;
using CodeBase.Infrastructure.Services.Pool.Pools;
using CodeBase.Infrastructure.Services.Randomizer;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.TileGeneration
{
    public class TileGenerator : ITileGenerator, IInitializable
    {
        private const float BLOCK_STEP = 4f; 
        
        private Vector3 _lastBlockPosition;
        private Vector3 _highDiamondPosition;

        private readonly IBlocksPool _blocksPool;  
        private readonly IDiamondsPool _diamondsPool;
        
        private readonly IRandomService _randomService;
        private readonly ICoroutineRunner _coroutineRunner;
        
        public bool IsSpawning { get; set; }

        public TileGenerator(IBlocksPool blocksPool, 
            IDiamondsPool diamondsPool,
            IRandomService randomService,
            ICoroutineRunner coroutineRunner)
        {
            _blocksPool = blocksPool;
            _diamondsPool = diamondsPool;
            _randomService = randomService;
            _coroutineRunner = coroutineRunner;
        }

        public void Initialize()
        {
            _lastBlockPosition = Vector3.zero;
            _highDiamondPosition = Vector3.up * 6f;
        }

        public void Init() => 
            InitPools();

        public IEnumerator StartSpawnRepeater()
        {
            yield return _coroutineRunner.StartCoroutine(SpawnRepeater());
        }

        private IEnumerator SpawnRepeater()  
        {  
            while (IsSpawning)  
            {  
                yield return new WaitForSeconds(0.2f);  
                if (IsSpawning == false)  
                    yield break;  
                SpawnTile();  
            }  
        }
        
        private void InitPools()  
        {  
            _blocksPool.Init();
            _diamondsPool.Init();
            
            for (int i = 0; i < 20; i++)   
                SpawnTile();  
            
            Debug.Log("Tile generator Initialized pools");
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
                currentPosition.x += BLOCK_STEP;  
            else  
                currentPosition.z -= BLOCK_STEP;  

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