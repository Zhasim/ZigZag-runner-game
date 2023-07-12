using System.Collections;
using CodeBase.Entity;
using CodeBase.Infrastructure.Services.Pool;
using CodeBase.Infrastructure.Services.Randomizer;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.TileGeneration
{
    public class TileGenerator : MonoBehaviour
    {
        [SerializeField] private int blockSize;
        [SerializeField] private int initBlocksCount;
        [SerializeField] private Player player;
        
        private Vector3 _lastPosition;
        private Vector3 _highPosition;
        private bool _hasGameFinished;
        
        private IPoolService _poolService;
        private IRandomService _randomService;
        
        [Inject]
<<<<<<< Updated upstream
        private void Construct(IPoolService poolService, IRandomService randomService)
=======
        public void Construct(IPoolService poolService, IRandomService randomService)
        {
            _poolService = poolService;
            _randomService = randomService;
        }


        private void Awake()
>>>>>>> Stashed changes
        {
            _poolService = poolService;
            _randomService = randomService;
        }

        private void OnEnable() => 
            player.OnPlayerDeath += GameOver;

        private void Start()  
        {
            blockSize = Constants.BLOCK_PREFAB_LOCAL_SCALE;
            initBlocksCount = Constants.INIT_BLOCKS_COUNT;

            _highPosition = Vector3.up * 6f;
            InitSpawn();
            StartCoroutine(SpawnRepeater());
        }

        private void OnDisable() => 
            player.OnPlayerDeath -= GameOver;
        

        private void InitSpawn()
        {
            for (int i = 0; i < initBlocksCount; i++) 
                SpawnTile();
        }

        private void SpawnTile()
        {
            //int randomValue = _randomService.Next(0, 2);

            int randomValue = Random.Range(0, 2);
            
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