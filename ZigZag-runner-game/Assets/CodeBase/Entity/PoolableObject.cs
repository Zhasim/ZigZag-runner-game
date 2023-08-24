using System.Collections;
using UnityEngine;

namespace CodeBase.Entity
{
    public abstract class PoolableObject : MonoBehaviour
    {
        protected abstract float DelayBeforeReturning { get; }
        protected abstract float DelayBeforeFalling { get; }

        private Rigidbody _rigidbody;

        protected virtual void Start() =>   
            _rigidbody = GetComponent<Rigidbody>();
        
        protected IEnumerator WaitAndFallDown()
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

        protected abstract void ReturnToPool();
    }
}