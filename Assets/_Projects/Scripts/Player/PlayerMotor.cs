using UnityEngine;

namespace JetpackJoyrideReplica.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMotor : MonoBehaviour
    {
        [SerializeField] private float _runningSpeed = 5f;
        [SerializeField] private float _flyingForce = 15f;
        private Rigidbody2D _rigidbody;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void MoveForward()
        {
            _rigidbody.linearVelocity = new Vector2(_runningSpeed, _rigidbody.linearVelocity.y);
        }

        public void FlyUp()
        {
            if (_rigidbody.linearVelocity.y < 8) _rigidbody.AddForce(Vector2.up * _flyingForce, ForceMode2D.Force);
        }

        public void StopAction()
        {
        }
    }
}