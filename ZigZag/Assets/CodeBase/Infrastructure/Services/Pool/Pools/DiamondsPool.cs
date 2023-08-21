using CodeBase.Data.GameLoopData;
using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Pool.Builder;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool.Pools
{
    public class DiamondsPool : IDiamondsPool
    {
        private const string DiamondsContainer = "DIAMONDS_CONTAINER";
        private const int InitialSize = 40;
        private const int MaxSize = 100;
        private const bool IsExpand = true;
        
        private readonly IGenericPool<Diamond> _genericPool;
        private WorldData _worldData;

        public DiamondsPool(IGenericPool<Diamond> genericPool) => 
            _genericPool = genericPool;

        public void Init(WorldData worldData)
        {
            _worldData = worldData;
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
            var diamond = _genericPool.Rent();
            diamond.Initialize(_worldData);
            return diamond;
        }

        public void ReturnDiamond(Diamond diamond)
        {
            diamond.Initialize(null); 
            _genericPool.Return(diamond);
        }
    }
}