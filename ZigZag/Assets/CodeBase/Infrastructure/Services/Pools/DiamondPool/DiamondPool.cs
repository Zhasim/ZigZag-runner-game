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
        private readonly HashSet<Diamond> _diamonds = new();

        public DiamondPool(Diamond.Pool pool) => 
            _pool = pool;
        public Diamond AddDiamond()
        
        {
            Diamond diamond = _pool.Spawn();
            _diamonds.Add(diamond);
            return diamond;
        }

        public void RemoveDiamond(Diamond diamond)
        {
            if (_diamonds.Contains(diamond))
            {
                _pool.Despawn(diamond);
                _diamonds.Remove(diamond);
            }
        }
    }
}