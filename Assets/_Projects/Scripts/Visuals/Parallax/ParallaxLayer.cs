using UnityEngine;

namespace JetpackJoyrideReplica.Visuals.Parallax
{
    [DefaultExecutionOrder(200)]
    public class ParallaxLayer : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTransform;

        [SerializeField] private float _parallaxFactor = 0.5f;

        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private Vector3 _cameraStartPosition;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Awake()
        {
            if (_cameraTransform != null) _cameraTransform = Camera.main.transform;

            _startPosition = transform.position;
            _cameraStartPosition = _cameraTransform.position;
        }

        // Update is called once per frame
        private void LateUpdate()
        {
            var cameraDelta = _cameraTransform.position - _cameraStartPosition;

            var targetX = _startPosition.x + cameraDelta.x * _parallaxFactor;

            transform.position = new Vector3(targetX, _startPosition.y, _startPosition.z);
        }
    }
}