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
            
            InitSpawn();
        }

        private void Update()
        {
            
        }

        private void InitSpawn()
        {
            for (int i = 0; i < initBlocksCount; i++) 
                SpawnBlock();
        }

        private void SpawnBlock()
        {
            int temp = _randomService.Next(0, 2);
            
            Vector3 currentPosition = _lastPosition;
            GameObject currentBlock = _poolService.GetFreeBlock();
            
            if (temp == 0)
                currentPosition.x += blockSize;
            else
                currentPosition.z -= blockSize;

            currentBlock.transform.position = currentPosition;
            _lastPosition = currentBlock.transform.position;
        }
        
    }
}