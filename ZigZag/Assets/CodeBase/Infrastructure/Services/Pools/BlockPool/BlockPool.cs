using System.Collections.Generic;
using CodeBase.Entity;

namespace CodeBase.Infrastructure.Services.Pools.BlockPool
{
    public class BlockPool : IBlockPool
    {
        private readonly Block.Pool _pool;
        private readonly List<Block> _blocks = new();

        public BlockPool(Block.Pool pool) => 
            _pool = pool;
        
        public void AddFoo() =>     
            _blocks.Add(_pool.Spawn());

        public void RemoveFoo()
        {
            if (_blocks.Count > 0)
            {
                Block foo = _blocks[0];
                _pool.Despawn(foo);
                _blocks.Remove(foo);
            }
        }
    }
}