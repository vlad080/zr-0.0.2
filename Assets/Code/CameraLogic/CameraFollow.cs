using UnityEngine;

namespace Code.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform Following;
        [SerializeField] private float RotationAngleX;
        [SerializeField] private int AngleZ, AngleY, DistanceZ;
        public float OffsetY;

        private void LateUpdate()
        {
            if (Following == null)
                return;

            Quaternion rotation = Quaternion.Euler(RotationAngleX, AngleY, AngleZ); 
            Vector3 position = rotation * new Vector3(0, 0, -DistanceZ) + FollowingPointPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(GameObject follow) => Following = follow.transform;

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = Following.position;
            followingPosition.y += OffsetY;
            return followingPosition;
        }
    }
}