using System;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace CodeBase.Entity
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed;

        private bool _hasGameStarted;
        private bool _isMovingForward;
        private Rigidbody _rigidbody;

        private IInputService _inputService;
        public event Action OnPlayerDeath;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _isMovingForward = true;
        }

        private void Update()
        {
            CheckGround();

            if (!_hasGameStarted)
            {
                if (Input.GetMouseButtonDown(0)) 
                    StartMove();
            }
            
            if (Input.GetMouseButtonDown(0)) 
                ChangeDirection();
        }

        private void ChangeDirection()
        {
            _rigidbody.velocity = (_isMovingForward ? Vector3.right : Vector3.back) * speed;
            _isMovingForward = !_isMovingForward;
        }

        private void StartMove()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _hasGameStarted = false;
                _rigidbody.velocity = Vector3.right * (speed * Time.deltaTime);
            }
        }

        private void CheckGround()
        {
            if (!Physics.Raycast(transform.position, Vector3.down, 2.0f))
            {
                _rigidbody.velocity = Vector3.down * 25f;
                if (!_hasGameStarted)
                {
                    _hasGameStarted = true;
                    OnPlayerDeath?.Invoke();
                    _rigidbody.constraints = RigidbodyConstraints.None;
                    Destroy(gameObject, 5.0f);
                }
            }
        }
    }
}