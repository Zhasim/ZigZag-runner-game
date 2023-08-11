using CodeBase.Entity.Player;
using UnityEngine;

namespace CodeBase.Logic.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        public float rotationAngleX = 30f;
        public float rotationAngleY = 120f;
        public float rotationAngleZ;
        
        public float distanceX = -4f;
        public float distanceY = 8f;
        public float distanceZ = 20f;
        
        public float offsetY = -6;

        [SerializeField] private PlayerDeath _player;
        [SerializeField] private Transform _target;
        [SerializeField] private bool _isPlayerDied;

        private void Start() => 
            _player.Died += OnPlayerDied;

        private void OnDestroy() =>
            _player.Died -= OnPlayerDied;

        private void LateUpdate()
        {
            if (_target != null) 
                ChasingTarget();
        }

        private void ChasingTarget()
        {
            if (!_isPlayerDied)
            {
                Quaternion rotation = Quaternion.Euler(rotationAngleX, rotationAngleY, rotationAngleZ);
                Vector3 position = rotation * new Vector3(distanceX, distanceY, -distanceZ) + FollowingPointPosition();
            
                transform.rotation = rotation;
                transform.position = position;
            }
        }

        public void Init(GameObject target, PlayerDeath playerDeath)
        {
            _target = target.transform;
            _player = playerDeath;
        }

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _target.position;
            followingPosition.y += offsetY;
            
            return followingPosition;
        }

        private void OnPlayerDied()
        {
            _isPlayerDied = true;
            _target = null;
            
            Debug.Log("Player has died, camera tracking stopped.");
        }
    }
}