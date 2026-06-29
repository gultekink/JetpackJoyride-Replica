using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] float offsetX;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetZ;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(cameraTransform.position.x + offsetX, cameraTransform.position.y + offsetY, cameraTransform.position.z + offsetZ);
    }
}
