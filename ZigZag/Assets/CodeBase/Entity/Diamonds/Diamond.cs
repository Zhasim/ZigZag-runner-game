using System.Collections;
using CodeBase.Infrastructure.Services.Pool.Pools;
using UnityEngine;
using Zenject;

namespace CodeBase.Entity.Diamonds
{
    public class Diamond : MonoBehaviour
    {
        private const float DelayBeforeFalling = 0.3f;
        private const float DelayBeforeReturning = 1f;

        [SerializeField] private DropZone _dropZone;
        [SerializeField] private FallZone _fallZone;

        private Rigidbody _rigidbody;
        private bool _dropped;
        private IDiamondsPool _pool;
        
        [Inject]
        public void Construct(IDiamondsPool pool) => 
            _pool = pool;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
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
            
            if (obj.CompareTag("Player"))
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

        private IEnumerator WaitAndFallDown()
        {
            yield return new WaitForSeconds(DelayBeforeFalling);
            FallDown();
        }

        private void FallDown()
        {
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            StartCoroutine(BackInPool());
        }

        private IEnumerator BackInPool()
        {
            yield return new WaitForSeconds(DelayBeforeReturning);
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;
            ReturnToPool();
        }

        private void ReturnToPool() => 
            _pool.ReturnDiamond(this);
    }
}