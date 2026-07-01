using System.Collections.Generic;
using JetpackJoyrideReplica.Level.Pooling;
using UnityEngine;

namespace JetpackJoyrideReplica.Level.Spawning
{
    public class LevelChunkSpawner : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private Transform _chunkFirstTransform;

        [SerializeField] private Transform _playerTransform;
        [SerializeField] private ChunkPool _chunkPool;

        [Header("Values")] [SerializeField] private float _nextSpawnX;

        [SerializeField] private float _spawnAheadDistance = 100;
        [SerializeField] private float _chunkLength = 50f;
        [SerializeField] private float _cleanupDistanceBehind = 100f;
        [SerializeField] private int _chunkCount = 2;

        private readonly List<GameObject> _spawnedChunks = new();

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            for (var i = 0; i < _chunkCount; i++) GenerateChunk();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_playerTransform.position.x + _spawnAheadDistance > _nextSpawnX) GenerateChunk();
            DeleteLastChunk();
        }

        private void GenerateChunk()
        {
            var spawnPosition = new Vector3(
                _nextSpawnX,
                _chunkFirstTransform.position.y,
                _chunkFirstTransform.position.z
            );

            var spawnedChunk = _chunkPool.Get(spawnPosition, Quaternion.identity);

            _spawnedChunks.Add(spawnedChunk);

            _nextSpawnX += _chunkLength;
        }

        private void DeleteLastChunk()
        {
            if (_spawnedChunks.Count == 0)
                return;

            var lastChunk = _spawnedChunks[0];

            var chunkEndX = lastChunk.transform.position.x + _chunkLength;
            var cleanupX = _playerTransform.position.x - _cleanupDistanceBehind;

            if (chunkEndX < cleanupX)
            {
                _chunkPool.Return(lastChunk);
                _spawnedChunks.RemoveAt(0);
            }
        }
    }
}