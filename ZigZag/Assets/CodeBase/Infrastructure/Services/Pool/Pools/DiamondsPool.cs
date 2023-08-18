using CodeBase.Data.GameLoopData;
using CodeBase.Entity.Diamonds;
using CodeBase.Infrastructure.Services.Pool.Builder;
using CodeBase.Infrastructure.Services.Progress.Registration;
using CodeBase.StaticData;
using CodeBase.Tools;
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
        private readonly IRegistrationService _registrationService;
        private readonly WorldData _worldData;

        public DiamondsPool(IGenericPool<Diamond> genericPool,
            IRegistrationService registrationService,
            WorldData worldData)
        {
            _genericPool = genericPool;
            _registrationService = registrationService;
            _worldData = worldData;
        }

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
            var diamond = _genericPool.Rent();
            diamond.GetComponent<UniqueId>().GenerateId();
            _registrationService.RegisterWatchers(diamond.gameObject);
            diamond.Init(_worldData);

            return diamond;
        }

        public void ReturnDiamond(Diamond diamond)
        {
            _registrationService.UnregisterWatchers(diamond.gameObject);
            diamond.Init(null);
            _genericPool.Return(diamond);
        }
    }
}