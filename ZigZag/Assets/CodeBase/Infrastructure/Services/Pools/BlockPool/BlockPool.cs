using System.Collections.Generic;
using CodeBase.Entity;

namespace CodeBase.Infrastructure.Services.Pools.BlockPool
{
    public class BlockPool : IBlockPool
    {
        private readonly Block.Pool _blockMemoryPool;
        private readonly HashSet<Block> _blocks = new();

        public BlockPool(Block.Pool blockMemoryPool) => 
            _blockMemoryPool = blockMemoryPool;
        
        public Block AddBlock()
        {
            Block block = _blockMemoryPool.Spawn();
            _blocks.Add(block);
            return block;
        }

        public void RemoveBlock(Block block)
        {
            if (_blocks.Contains(block))
            {
                _blockMemoryPool.Despawn(block);
                _blocks.Remove(block);
            }
        }
    }
}