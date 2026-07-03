using System.Collections.Generic;
using JetpackJoyrideReplica.Obstacles.Pooling;
using UnityEngine;

namespace JetpackJoyrideReplica.Obstacles.Spawning
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private GameObject _obstacleObject;

        [SerializeField] private Transform _playerTransform;
        [SerializeField] private ObstaclePool _obstaclePool;

        [Header("Spawn Settings")] [SerializeField]
        private float _spawnDistanceAhead = 30;

        [SerializeField] private float _spawnIntervalX = 30f;
        [SerializeField] private float _minSpawnY;
        [SerializeField] private float _maxSpawnY = 8f;
        [SerializeField] private float _cleanupDistanceBehind = 50;


        private float _nextSpawnX = 25;

        private readonly List<GameObject> _spawnedObstacles = new();


        // Update is called once per frame
        private void Update()
        {
            if (_playerTransform.position.x + _spawnDistanceAhead > _nextSpawnX) GenerateObstacle();

            DeleteLastObstacle();
        }

        private void GenerateObstacle()
        {
            var randomY = Random.Range(_minSpawnY, _maxSpawnY);

            var spawnPosition = new Vector3(_nextSpawnX, randomY, 0f);

            var obj = _obstaclePool.Get(spawnPosition, Quaternion.identity);
            _nextSpawnX += _spawnIntervalX;

            _spawnedObstacles.Add(obj);
        }

        private void DeleteLastObstacle()
        {
            if (_spawnedObstacles.Count == 0)
                return;

            var oldestObstacle = _spawnedObstacles[0];

            var cleanupX = _playerTransform.position.x - _cleanupDistanceBehind;

            if (oldestObstacle.transform.position.x < cleanupX)
            {
                _obstaclePool.Return(oldestObstacle);
                _spawnedObstacles.RemoveAt(0);
            }
        }
    }
}