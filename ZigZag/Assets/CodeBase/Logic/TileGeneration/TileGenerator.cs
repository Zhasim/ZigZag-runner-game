using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Logic.TileGeneration
{
    public class TileGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject blockPrefab;

        private float _blockSize;
        private Vector3 _lastPos;

        private BlockPoolService _blockPool;
        private readonly IGameFactory _factory;

        private void Start()
        {
            _lastPos = blockPrefab.transform.position;
            _blockSize = blockPrefab.transform.localScale.x;
            _blockPool = new BlockPoolService(blockPrefab, Constants.POOL_SIZE, transform, _factory);
        }
    }
}