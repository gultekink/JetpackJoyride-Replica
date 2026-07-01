using System;
using JetpackJoyrideReplica.Player;
using UnityEngine;

namespace JetpackJoyrideReplica.Collectibles
{
    public class Coin : MonoBehaviour
    {
        public Action<Coin> Collected;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponentInParent<PlayerController>() == null) return;
            Collected?.Invoke(this);
        }
    }
}