using System;
using CodeBase.Infrastructure.Services.Pools;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.TileGeneration
{
    public class Pooler : MonoBehaviour
    {
        private IBlocksPool _pool;

        [Inject]
        private void Construct(IBlocksPool pool) => 
            _pool = pool;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A)) 
                _pool.CreatePool(10);
            if (Input.GetKeyDown(KeyCode.B)) 
                _pool.GetFreeElement();
        }
    }
}