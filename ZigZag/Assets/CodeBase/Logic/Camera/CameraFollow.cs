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

        [SerializeField] private Transform target;
        
        private void LateUpdate()
        {
            if (target == null)
                return;
            Quaternion rotation = Quaternion.Euler(rotationAngleX, rotationAngleY, rotationAngleZ);
            Vector3 position = rotation * new Vector3(distanceX, distanceY, -distanceZ) + FollowingPointPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(GameObject target) => 
            this.target = target.transform;

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = target.position;
            followingPosition.y += offsetY;
            
            return followingPosition;
        }
    }
}