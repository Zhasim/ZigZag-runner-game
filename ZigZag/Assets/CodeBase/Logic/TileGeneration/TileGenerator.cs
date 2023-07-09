using CodeBase.DI;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factory;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Logic.TileGeneration
{
    public class TileGenerator : MonoBehaviour
    {
        private float _blockSize;
        private Vector3 _lastPos;
        
        private readonly IGameFactory _factory;
        private readonly ServiceLocator _serviceLocator;

        private void Start()
        {
        }
        
    }
}