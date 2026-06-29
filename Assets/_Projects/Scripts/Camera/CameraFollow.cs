using UnityEngine;

namespace JetpackJoyrideReplica.Cameras
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float offsetX;
        [SerializeField] private float offsetY;
        [SerializeField] private float offsetZ;
        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = new Vector3(target.position.x + offsetX, offsetY, target.position.z + offsetZ);
        }
    }

}
