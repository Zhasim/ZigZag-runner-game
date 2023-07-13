using System.Collections;
using CodeBase.Entity;
using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Pools;
using CodeBase.Infrastructure.Services.Pools.BlockPool;
using CodeBase.Infrastructure.Services.Pools.DiamondPool;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace CodeBase.Logic.TileGeneration
{
    public class TileGenerator : MonoBehaviour
    {
        [SerializeField] private int initBlocksCount;

        [SerializeField] private Block blockPrefab;
        [SerializeField] private Diamond diamondPrefab;
        [SerializeField] private Player player;

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

        private void OnEnable() => 
            player.OnPlayerDeath += GameOver;

        private void Start()
        {
            initBlocksCount = Constants.INIT_BLOCKS_COUNT;

            _highPosition = Vector3.up * 6f;
            _blockSize = blockPrefab.transform.localScale.x;
            
            InitSpawn();
            //StartCoroutine(SpawnRepeater());
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
        GameObject currentBlock = _blockPool.GetFreeElement();
        
        if (randomValue == 0)
            currentPosition.x += _blockSize;
        else
            currentPosition.z -= _blockSize;
    
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