using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Pool.Builder;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool.Pools
{
    public class DiamondsPool : IDiamondsPool
    {
        private const int InitialSize = 40;
        private const int MaxSize = 100;
        private const bool IsExpand = true;
        private const string DiamondsContainer = "DIAMONDS_CONTAINER";
        
        private readonly IGenericPool<Diamond> _genericPool;

        public DiamondsPool(IGenericPool<Diamond> genericPool) => 
            _genericPool = genericPool;

        public void Init()
        {
            Transform parent = new GameObject(DiamondsContainer).transform;

            _genericPool.SetPrefabResource(ResourcePath.DIAMOND)
                .SetInitialSize(InitialSize)
                .SetMaxSize(MaxSize)
                .ExpandByDoubling(true)
                .UnderTransformGroup(parent);
            
            _genericPool.Initialize();

            Debug.Log("BlocksPool initialized");
        }
        
        public Diamond RentDiamond()
        {
            return _genericPool.Rent();
        }

        public void ReturnDiamond(Diamond diamond)
        {
            _genericPool.Return(diamond);
        }
    }
}