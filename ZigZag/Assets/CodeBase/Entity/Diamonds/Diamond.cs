using System.Collections;
using CodeBase.Data;
using CodeBase.Infrastructure.Services.Pool.Pools;
using CodeBase.Infrastructure.Services.Progress.Watchers;
using UnityEngine;
using Zenject;

namespace CodeBase.Entity.Diamonds
{
    public class Diamond : PoolableObject, IProgressWriter
    {
        private const string PlayerTag = "Player";
        
        [SerializeField] private DropZone _dropZone;
        [SerializeField] private FallZone _fallZone;
        
        private IDiamondsPool _pool;
        private WorldData _worldData;
        private bool _dropped;

        protected override float DelayBeforeReturning => 1.0f;
        protected override float DelayBeforeFalling => 0.3f;
        
        [Inject]
        public void Construct(IDiamondsPool pool) => 
            _pool = pool;

        public void Init(WorldData worldData) =>
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
                Collect();
                ReturnToPool();
            }
        }

        private void OnTriggerExited(Collider obj)
        {
            if(_dropped)
                return;

            if (!_dropped) 
                StartCoroutine(WaitAndFallDown());
        }

        private void Collect()
        {
            _dropped = true;
            _worldData.DiamondsData.Collect();
        }

        protected override void ReturnToPool() => 
            _pool.ReturnDiamond(this);

        public void WriteProgress(OverallProgress progress)
        {
            if(_dropped)
                return;
        }
    }
}