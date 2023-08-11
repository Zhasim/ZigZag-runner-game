using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Entity.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerDeath : MonoBehaviour
    {
        private const float DelayBeforeDeath = 0.25f;
        private const float DelayBeforeDestroy = 2f;
        private const float FallSpeed = 25f;
        
        private Rigidbody _rigidbody;
        private bool _isDied;

        public event Action Died;
        
        private void Start() =>
            _rigidbody = GetComponent<Rigidbody>();

        private void Update() => 
            CheckGround();

        private void CheckGround()
        {
            if (!IsGrounded())
            {
                FallDown();
                
                if (!_isDied) 
                    StartCoroutine(Die());
            }
        }

        private bool IsGrounded() => 
            Physics.Raycast(transform.position, Vector3.down, 2.0f);

        private void FallDown() => 
            _rigidbody.velocity = Vector3.down * FallSpeed;

        private IEnumerator Die()
        {
            _isDied = true;
            ResetRigidBody();
            
            yield return new WaitForSeconds(DelayBeforeDeath);
            Died?.Invoke();
            Debug.Log("Player died");
            
            StartCoroutine(DestroyAfterDeath());
        }

        private IEnumerator DestroyAfterDeath()
        {
            yield return new WaitForSeconds(DelayBeforeDestroy);
            Destroy(gameObject);
        }

        private void ResetRigidBody() => 
            _rigidbody.constraints = RigidbodyConstraints.None;
    }
}