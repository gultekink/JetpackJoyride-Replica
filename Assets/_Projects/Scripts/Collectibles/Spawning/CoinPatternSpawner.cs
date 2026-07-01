using System.Collections.Generic;
using JetpackJoyrideReplica.Collectibles.Patterns;
using UnityEngine;

namespace JetpackJoyrideReplica.Collectibles.Spawning
{
    public class CoinPatternSpawner : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private CoinPool _coinPool;

        [SerializeField] private Transform _playerTransform;
        [SerializeField] private CoinPattern[] _coinPatterns;

        [Header("Values")] [SerializeField] private float _spawnDistanceAhead = 30f;

        [SerializeField] private float _spawnIntervalX = 20f;
        [SerializeField] private float _anchorY = 3f;
        [SerializeField] private float _cleanupDistanceBehind = 20f;
        [SerializeField] private float _initialSpawnX = 25f;

        private readonly List<Coin> _spawnedCoins = new();

        private float _nextSpawnX;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            _nextSpawnX = _initialSpawnX;
        }

        // Update is called once per frame
        private void Update()
        {
            if (_playerTransform.position.x + _spawnDistanceAhead > _nextSpawnX) SpawnNextPattern();
            CheckDeleteCoins();
        }

        private void SpawnNextPattern()
        {
            if (_coinPatterns == null || _coinPatterns.Length == 0) return;
            var anchorPosition = new Vector3(_nextSpawnX, _anchorY, 0f);
            var coinPattern = _coinPatterns[Random.Range(0, _coinPatterns.Length)];
            SpawnPattern(coinPattern, anchorPosition);
            _nextSpawnX += _spawnIntervalX;
        }

        private void SpawnPattern(CoinPattern pattern, Vector3 anchorPosition)
        {
            foreach (var localPosition in pattern.LocalPositions)
            {
                var position = anchorPosition + new Vector3(localPosition.x, localPosition.y, 0f);
                var createdCoin = _coinPool.Get(position, Quaternion.identity);
                _spawnedCoins.Add(createdCoin);
                createdCoin.Collected += HandleCoinCollected;
            }
        }

        private void HandleCoinCollected(Coin coin)
        {
            coin.Collected -= HandleCoinCollected;
            _spawnedCoins.Remove(coin);
        }

        private void CheckDeleteCoins()
        {
            float cleanupX = _playerTransform.position.x - _cleanupDistanceBehind;
            
            for (int i = _spawnedCoins.Count - 1; i >= 0; i--)
            {
                Coin coin = _spawnedCoins[i];

                if (coin.transform.position.x < cleanupX)
                {
                    coin.Collected -= HandleCoinCollected;
                    _coinPool.Return(coin);
                    _spawnedCoins.RemoveAt(i);
                }
            }
        }
    }
}

