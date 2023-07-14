using System.Collections;
using CodeBase.Infrastructure.Services.Pools.BlockPool;
using CodeBase.Infrastructure.Services.Pools.DiamondPool;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace CodeBase.Logic.TileGeneration
{
    public class TileGenerator : MonoBehaviour
    {
        private const int INIT_BLOCK_COUNT = 30;
        private const int INIT_DIAMONDS_COUNT = 15;
        private const int BLOCK_SIZE = 4;

        private IBlockPool _blockPool;
        private IDiamondPool _diamondPool;

        private Vector3 _lastPosition;
        private Vector3 _highPosition;
        
        private float _blockSize;
        private bool _hasGameFinished;
        
        [Inject]
        private void Construct(IBlockPool blockPool, IDiamondPool diamondPool)
        {
            _diamondPool = diamondPool;
            _blockPool = blockPool;
        }

        private void Start()
        {
            _lastPosition = Vector3.zero;
            _highPosition = Vector3.up * 6f;

            InitPools();
            // SpawnTile();
            // InitSpawn();
            //StartCoroutine(SpawnRepeater());
        }

        private void InitPools()
        {
            _blockPool.CreatePool(INIT_BLOCK_COUNT);
            _diamondPool.CreatePool(INIT_DIAMONDS_COUNT);
        }

        private void InitSpawn()
        {
            for (int i = 0; i < INIT_BLOCK_COUNT; i++) 
                SpawnTile();
        }
    
        private void SpawnTile()
        {
            //int randomValue = _randomService.Next(0, 2);
        
            int randomValue = Random.Range(0, 2);
            Vector3 currentPosition = _lastPosition;

            if (randomValue == 0)
                currentPosition.x += BLOCK_SIZE;
            else
                currentPosition.z -= BLOCK_SIZE;
        
            GameObject currentBlock = _blockPool.GetFreeElement();
            currentBlock.transform.position = currentPosition;
            _lastPosition = currentBlock.transform.position;
        
            int chanceToDiamond = Random.Range(0, 4);
            SpawnDiamond(chanceToDiamond);
        }
        
        private void SpawnDiamond(int chanceToDiamond)
        {
            if (chanceToDiamond == 0)
            {
                GameObject diamond = _diamondPool.GetFreeElement();
                diamond.transform.position = _lastPosition + _highPosition;
            }
        }
        
        private IEnumerator SpawnRepeater()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.2f);
                if (_hasGameFinished == true)
                    yield break;
                SpawnTile();
            }
        }
        
        private void GameOver() => 
            _hasGameFinished = true;
    }
}