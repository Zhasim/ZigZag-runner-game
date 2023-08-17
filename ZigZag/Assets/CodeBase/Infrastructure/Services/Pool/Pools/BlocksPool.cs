using CodeBase.Entity;
using CodeBase.Infrastructure.Services.Pool.Builder;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool.Pools
{
    public class BlocksPool : IBlocksPool
    {
        private const int InitialSize = 20;
        private const int MaxSize = 80;
        private const bool IsExpand = true;
        private const string BlocksContainer = "BLOCKS_CONTAINER";
        
        private readonly IPoolBuilder<Block> _poolBuilder;

        public BlocksPool(IPoolBuilder<Block> poolBuilder) => 
            _poolBuilder = poolBuilder;

        public void Init()
        {
            Transform parent = new GameObject(BlocksContainer).transform;

            _poolBuilder.SetPrefabResource(ResourcePath.BLOCK)
                .SetInitialSize(InitialSize)
                .SetMaxSize(MaxSize)
                .ExpandByDoubling(IsExpand)
                .UnderTransformGroup(parent);
            
            _poolBuilder.Initialize();
            
            Debug.Log("BlocksPool initialized");

        }
        
        public Block RentBlock()
        {
            return _poolBuilder.Rent();
        }

        public void ReturnBlock(Block block)
        {
            _poolBuilder.Return(block);
        }
    }
}