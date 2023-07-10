using CodeBase.Infrastructure.Services.Pool;
using CodeBase.Infrastructure.Services.Randomizer;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Logic.TileGeneration
{
    public class TileGenerator : MonoBehaviour
    {
        [SerializeField] private int blockSize;
        [SerializeField] private int initBlocksCount;
        
        private Vector3 _lastPosition;
        private Vector3 _highPosition;
        
        private IPoolService _poolService;
        private IRandomService _randomService;

        public void Construct(IPoolService poolService, IRandomService randomService)
        {
            _poolService = poolService;
            _randomService = randomService;
        }

        private void Start()  
        {
            blockSize = Constants.BLOCK_PREFAB_LOCAL_SCALE;
            initBlocksCount = Constants.INIT_BLOCKS_COUNT;
            
            _highPosition = Vector3.up * 6f;
            InitSpawn();
        }

        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.A))
        //     {
        //         InitSpawn();
        //     }
        // }

        private void InitSpawn()
        {
            for (int i = 0; i < initBlocksCount; i++) 
                SpawnTile();
        }

        private void SpawnTile()
        {
            int randomValue = _randomService.Next(0, 2);
            
            Vector3 currentPosition = _lastPosition;
            GameObject currentBlock = _poolService.GetFreeBlock();
            
            if (randomValue == 0)
                currentPosition.x += blockSize;
            else
                currentPosition.z -= blockSize;

            currentBlock.transform.position = currentPosition;
            _lastPosition = currentBlock.transform.position;

            int chanceToDiamond = _randomService.Next(0, 4);
            SpawnDiamond(chanceToDiamond);
        }

        private void SpawnDiamond(int chanceToDiamond)
        {
            if (chanceToDiamond == 0)
            {
                GameObject diamond = _poolService.GetFreeDiamond();
                diamond.transform.position = _lastPosition + _highPosition;
            }
        }
    }
}