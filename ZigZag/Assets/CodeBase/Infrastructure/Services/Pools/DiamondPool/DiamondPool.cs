using System.Collections.Generic;
using CodeBase.Entity;
using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pools.DiamondPool
{
    public class DiamondPool : IDiamondPool
    {
        private readonly Diamond.Pool _pool;
        private readonly List<Diamond> _blocks = new();

        public DiamondPool(Diamond.Pool pool) => 
            _pool = pool;
        
        public void AddFoo() =>     
            _blocks.Add(_pool.Spawn());

        public void RemoveFoo()
        {
            if (_blocks.Count > 0)
            {
                Diamond foo = _blocks[0];
                _pool.Despawn(foo);
                _blocks.Remove(foo);
            }
        }
    }
}