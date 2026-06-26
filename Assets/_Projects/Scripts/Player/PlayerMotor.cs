using UnityEngine;

namespace JetpackJoyrideReplica.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMotor : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        [SerializeField] private float _runningSpeed = 5f;
        [SerializeField] private float _flyingSpeed = 15f;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
   
        public void MoveForward()
        {
            _rigidbody.linearVelocity = new Vector2(_runningSpeed, _rigidbody.linearVelocity.y);
        }

        public void FlyUp()
        {
            _rigidbody.AddForce(Vector2.up * _flyingSpeed, ForceMode2D.Force);
        }

    }

}
