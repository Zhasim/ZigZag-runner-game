using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Entity.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float initialSpeed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float accelerationRate;
        
        [SerializeField] private float _currentSpeed;
        
        private bool _hasGameStarted;
        private bool _hasGameFinished;
        
        private bool _isMovingForward;
        private Rigidbody _rigidbody;

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService) => 
            _inputService = inputService;

        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody>();

        private void Start()
        {
            _currentSpeed = initialSpeed;
            _isMovingForward = true;
        }

        private void Update()
        {
            HandleInput();
            UpdateCurrentSpeed();
        }

        private void HandleInput()
        {
            if (!_hasGameStarted && _inputService.GetInputDown())
            {
                StartMove();
                _hasGameStarted = true;
            }
            
            if (_inputService.GetInputDown()) 
                ChangeDirection();
        }

        private void ChangeDirection()
        {
            _rigidbody.velocity = (_isMovingForward ? Vector3.right : Vector3.back) * _currentSpeed;
            _isMovingForward = !_isMovingForward;
        }

        private void UpdateCurrentSpeed()
        {
            if (_hasGameStarted && _currentSpeed < maxSpeed)
            {
                _currentSpeed += accelerationRate * Time.deltaTime;
                _currentSpeed = Mathf.Clamp(_currentSpeed, initialSpeed, maxSpeed);
            }
        }

        private void StartMove()
        {
            if(_hasGameStarted)
                return;
            _rigidbody.velocity = Vector3.right * (_currentSpeed * Time.deltaTime);
        }
    }
}