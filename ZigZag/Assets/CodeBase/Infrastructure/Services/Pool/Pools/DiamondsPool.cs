using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Pool.Builder;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool.Pools
{
    public class DiamondsPool : IDiamondsPool
    {
        private const int InitialSize = 20;
        private const int MaxSize = 60;
        private const bool IsExpand = true;
        private const string DiamondsContainer = "DIAMONDS_CONTAINER";
        
        private readonly IPoolBuilder<Diamond> _pool;

        public DiamondsPool(IPoolBuilder<Diamond> pool) => 
            _pool = pool;

        public void Init()
        {
            Transform parent = new GameObject(DiamondsContainer).transform;

            _pool.SetPrefabResource(ResourcePath.DIAMOND)
                .SetInitialSize(InitialSize)
                .SetMaxSize(MaxSize)
                .ExpandByDoubling(IsExpand)
                .UnderTransformGroup(parent);
            
            _pool.Initialize();

            Debug.Log("BlocksPool initialized");
        }
        
        public Diamond RentDiamond()
        {
            return _pool.Rent();
        }

        public void ReturnDiamond(Diamond diamond)
        {
            _pool.Return(diamond);
        }
    }
}