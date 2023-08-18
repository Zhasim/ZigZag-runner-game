using CodeBase.Entity.Blocks;
using CodeBase.Infrastructure.Services.Pool.Builder;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool.Pools
{
    public class BlocksPool : IBlocksPool
    {
        private const int InitialSize = 100;
        private const int MaxSize = 200;
        private const bool IsExpand = true;
        private const string BlocksContainer = "BLOCKS_CONTAINER";
        
        private readonly IGenericPool<Block> _genericPool;
        
        public BlocksPool(IGenericPool<Block> genericPool) => 
            _genericPool = genericPool;

        public void Init()
        {
            Transform parent = new GameObject(BlocksContainer).transform;

            _genericPool.SetPrefabResource(ResourcePath.BLOCK)
                .SetInitialSize(InitialSize)
                .SetMaxSize(MaxSize)
                .ExpandByDoubling(IsExpand)
                .UnderTransformGroup(parent);
            
            _genericPool.Initialize();
            
            Debug.Log("BlocksPool initialized");
        }
        
        public Block RentBlock() => 
            _genericPool.Rent();

        public void ReturnBlock(Block block) => 
            _genericPool.Return(block);
    }
}