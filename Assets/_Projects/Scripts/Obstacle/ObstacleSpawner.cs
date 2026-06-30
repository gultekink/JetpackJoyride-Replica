using System.Collections.Generic;
using JetpackJoyrideReplica.Obstacles.Pooling;
using UnityEngine;

namespace JetpackJoyrideReplica.Obstacles.Spawning
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject _obstacleObject;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private ObstaclePool _obstaclePool;

        [Header("Spawn Settings")]
        [SerializeField] private float _spawnDistanceAhead = 30;
        [SerializeField] private float _spawnIntervalX = 30f;
        [SerializeField] private float _minSpawnY = 0f;
        [SerializeField] private float _maxSpawnY = 8f;
        [SerializeField] private float _cleanupDistanceBehind = 50;

        private List<GameObject> _spawnedObstacles = new List<GameObject>();
        

        private float _nextSpawnX = 25;
            

        // Update is called once per frame
        void Update()
        {
            if (_playerTransform.position.x + _spawnDistanceAhead > _nextSpawnX)
            {
                GenerateObstacle();
            }

            DeleteLastObstacle();
        }

        void GenerateObstacle()
        {
            float randomY = Random.Range(_minSpawnY, _maxSpawnY);

            Vector3 spawnPosition = new Vector3(_nextSpawnX, randomY, 0f);

            GameObject obj = _obstaclePool.Get(spawnPosition, Quaternion.identity);
            _nextSpawnX += _spawnIntervalX;

            _spawnedObstacles.Add(obj);
        }

        void DeleteLastObstacle()
        {
            if (_spawnedObstacles.Count == 0)
                return;

            GameObject oldestObstacle = _spawnedObstacles[0];

            float cleanupX = _playerTransform.position.x - _cleanupDistanceBehind;

            if (oldestObstacle.transform.position.x < cleanupX)
            {
                _obstaclePool.Return(oldestObstacle);
                _spawnedObstacles.RemoveAt(0);
            }
        }
    }
}

