using CodeBase.Data;
using CodeBase.Data.GameLoopData;
using CodeBase.Infrastructure.Services.Pool.Pools;
using CodeBase.Infrastructure.Services.Progress.Watchers;
using UnityEngine;
using Zenject;

namespace CodeBase.Entity.Diamonds
{
    public class Diamond : PoolableObject
    {
        private const string PlayerTag = "Player";
        
        [SerializeField] private DropZone _dropZone;
        [SerializeField] private FallZone _fallZone;
        
        private IDiamondsPool _pool;
        private bool _dropped;
        private WorldData _worldData;

        protected override float DelayBeforeReturning => 1.0f;
        protected override float DelayBeforeFalling => 0.3f;
        
        [Inject]
        public void Construct(IDiamondsPool pool) => 
            _pool = pool;

        public void Initialize(WorldData worldData) => 
            _worldData = worldData;

        protected override void Start()
        {
            base.Start();
            _dropZone.TriggerEnter += OnTriggerEntered;
            _fallZone.TriggerExit += OnTriggerExited;
        }

        private void OnDestroy()
        {
            _dropZone.TriggerEnter -= OnTriggerEntered;
            _fallZone.TriggerExit -= OnTriggerExited;
        }

        private void OnTriggerEntered(Collider obj)
        {
            if(_dropped)
                return;

            if (obj.CompareTag(PlayerTag))
            {
                _dropped = true;
                Collect();
            } 
        }

        private void Collect()
        {
            _worldData.DiamondsData.Collect();
            ReturnToPool();
        }

        private void OnTriggerExited(Collider obj)
        {
            if(_dropped)
                return;

            if (!_dropped) 
                StartCoroutine(WaitAndFallDown());
        }
        
        protected override void ReturnToPool() => 
            _pool.ReturnDiamond(this);

        public void ReadProgress(OverallProgress progress)
        {
            throw new System.NotImplementedException();
        }
    }
}