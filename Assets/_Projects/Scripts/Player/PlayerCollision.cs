using UnityEngine;
using JetpackJoyrideReplica.Obstacles;

namespace JetpackJoyrideReplica.Player
{
    public class PlayerCollision : MonoBehaviour
    {
        PlayerController controller;
        private void Awake()
        {
            controller = GetComponent<PlayerController>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Obstacle obstacle))
            {
                controller.Die();
                Debug.Log("Death");
            }
        }
    }

}
