using System.Collections;
using UnityEngine;
using Zenject;

namespace CodeBase.Entity
{
    public class Block : MonoBehaviour
    {
        private const float DelayBeforeReturning = 2.0f;
        private const float DelayBeforeFalling = 0.1f;
        private Rigidbody _rigidbody;
        

        private void Start() =>   
            _rigidbody = GetComponent<Rigidbody>();

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.CompareTag("Player"))
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
        }
    }
}