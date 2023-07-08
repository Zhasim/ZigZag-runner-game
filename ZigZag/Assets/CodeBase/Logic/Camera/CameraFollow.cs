using UnityEngine;

namespace CodeBase.Logic.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        public float RotationAngleX;
        public float Distance;
        public float OffsetY;

        [SerializeField] private Transform _target;
        
        private void LateUpdate()
        {
            if (_target == null)
                return;
            Quaternion rotation = Quaternion.Euler(RotationAngleX, 0, 0);
            Vector3 position = rotation * new Vector3(0, 0, -Distance) + FollowingPointPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(GameObject target) => 
            _target = target.transform;

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _target.position;
            followingPosition.y += OffsetY;
            
            return followingPosition;
        }
    }
}