using System.Collections;
using UnityEngine;
using Zenject;

namespace CodeBase.Entity.Diamonds
{
    public class Diamond : MonoBehaviour
    {
        private const float DelayBeforeFalling = 0.3f;
        
        [SerializeField] private DropZone _dropZone;
        [SerializeField] private FallZone _fallZone;
        
        private Rigidbody _rigidbody;
        private bool _dropped;

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
                Destroy(gameObject);
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
        }

        public class Pool : MonoMemoryPool<Diamond>
        {
            
        }
    }
}