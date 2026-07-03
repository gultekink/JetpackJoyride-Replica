using UnityEngine;

namespace JetpackJoyrideReplica.Collectibles.Patterns
{
    [CreateAssetMenu(fileName = "CoinPattern", menuName = "Collectibles/CoinPattern")]
    public class CoinPattern : ScriptableObject
    {
        [SerializeField] private string _patternName;
        [SerializeField] private Vector2[] _localPositions;

        public string PatternName => _patternName;
        public Vector2[] LocalPositions => _localPositions;
    }
}