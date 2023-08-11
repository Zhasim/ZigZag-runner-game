using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace CodeBase.Entity.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float speed;

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

        private void Start() => 
            _isMovingForward = true;

        private void Update()
        {
            if (!_hasGameStarted)
            {
                if (_inputService.GetInputDown())
                {
                    StartMove();
                    _hasGameStarted = true;
                }
            }
            
            if (_inputService.GetInputDown()) 
                ChangeDirection();
        }

        private void ChangeDirection()
        {
            _rigidbody.velocity = (_isMovingForward ? Vector3.right : Vector3.back) * speed;
            _isMovingForward = !_isMovingForward;
        }
        
        private void StartMove()
        {
            if(_hasGameStarted)
                return;
            _rigidbody.velocity = Vector3.right * (speed * Time.deltaTime);
        }
    }
}