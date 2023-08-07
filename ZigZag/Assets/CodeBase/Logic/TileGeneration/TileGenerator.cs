using System.Collections;
using CodeBase.Entity;
using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Foundation.CoroutineAccess;
using CodeBase.Infrastructure.Services.Pools.BlockPool;
using CodeBase.Infrastructure.Services.Pools.DiamondPool;
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
        
        private readonly IRandomService _randomService;  
        private readonly IBlockPool _blockPool;  
        private readonly IDiamondPool _diamondPool;
        private readonly ICoroutineRunner _coroutineRunner;

        public bool IsSpawning { get; set; }

        public TileGenerator(IRandomService randomService, IBlockPool blockPool, IDiamondPool diamondPool, ICoroutineRunner coroutineRunner)
        {
            _randomService = randomService;
            _blockPool = blockPool;
            _diamondPool = diamondPool;
            _coroutineRunner = coroutineRunner;
        }

        public void Initialize()
        {
            _lastBlockPosition = Vector3.zero;
            _highDiamondPosition = Vector3.up * 6f;
        }

        public void Init() => 
            InitSpawn();

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
        
        private void InitSpawn()  
        {  
            for (int i = 0; i < 20; i++)   
                SpawnTile();  
        }
        
        private void SpawnTile()  
        {  
            Vector3 currentPosition = CalculateNextBlockPosition(); 
            Block currentBlock = _blockPool.AddBlock();  

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
                Diamond diamond = _diamondPool.AddDiamond();
                diamond.transform.position = _lastBlockPosition + _highDiamondPosition;
            }  
        }
    }
}