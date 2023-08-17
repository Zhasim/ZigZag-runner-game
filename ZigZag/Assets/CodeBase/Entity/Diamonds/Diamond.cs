using System.Collections;
using CodeBase.Infrastructure.Services.Pool.Pools;
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
        
        protected override float DelayBeforeReturning => 1.0f;
        protected override float DelayBeforeFalling => 0.3f;
        
        [Inject]
        public void Construct(IDiamondsPool pool) => 
            _pool = pool;

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
        
        protected override void ReturnToPool() => 
            _pool.ReturnDiamond(this);
    }
}