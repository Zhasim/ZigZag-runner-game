using System.Collections;
using CodeBase.Entity;
using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Pools;
using CodeBase.StaticData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Logic.TileGeneration
{
    public class TileGenerator : MonoBehaviour
    {
        [SerializeField] private int initBlocksCount;

        [SerializeField] private Block blockPrefab;
        [SerializeField] private Diamond diamondPrefab;
        [SerializeField] private Player player;

        private IBlocksPool _blocksPPP;
        private LocalFactory<Block> _blockFactory;
        private LocalFactory<Diamond> _diamondFactory;

        private PoolMono<Block> _blockPool;
        private PoolMono<Diamond> _diamondPool;
        
        private Vector3 _lastPosition;
        private Vector3 _highPosition;
        private float _blockSize;
        private bool _hasGameFinished;
        
        private void OnEnable() => 
            player.OnPlayerDeath += GameOver;

        private void Start()
        {
            initBlocksCount = Constants.INIT_BLOCKS_COUNT;

            _blockFactory = new LocalFactory<Block>(blockPrefab);
            _diamondFactory = new LocalFactory<Diamond>(diamondPrefab);

            _blockPool = new PoolMono<Block>(blockPrefab, 10, transform, _blockFactory);
            _diamondPool = new PoolMono<Diamond>(diamondPrefab, 10, transform, _diamondFactory);
            
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
        Block currentBlock = _blockPool.GetFreeElement();
        
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
            Diamond diamond = _diamondPool.GetFreeElement();
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