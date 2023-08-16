using CodeBase.Entity.Player;
using UnityEngine;
using Zenject;

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
        
        [SerializeField] private Transform _target;

        private void LateUpdate()
        {
            if (_target != null) 
                ChasingTarget();
        }

        public void Follow(GameObject target) => 
            _target = target.transform;

        public void StopFollowing()
        {
            _target = null;
            
            Debug.Log("Player has died, camera tracking stopped.");
        }

        private void ChasingTarget()
        {
            Quaternion rotation = Quaternion.Euler(rotationAngleX, rotationAngleY, rotationAngleZ);
                Vector3 position = rotation * new Vector3(distanceX, distanceY, -distanceZ) + FollowingPointPosition();
            
                transform.rotation = rotation;
                transform.position = position;
        }

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _target.position;
            followingPosition.y += offsetY;
            
            return followingPosition;
        }
    }
}