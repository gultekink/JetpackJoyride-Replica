using System.Collections.Generic;
using UnityEngine;

namespace JetpackJoyrideReplica.LevelChunk
{
    public class LevelChunkSpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject _chunkObject;
        [SerializeField] private Transform _chunkFirstTransform;
        [SerializeField] private Transform _playerTransform;

        private List<GameObject> _spawnedChunks = new List<GameObject>();

        private float _nextSpawnX = 0;
        private float _spawnAheadDistance = 100;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            for (int i = 0; i < 2; i++)
            {
                GenerateChunk();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (_playerTransform.position.x + _spawnAheadDistance > _nextSpawnX)
            {
                GenerateChunk();
            }
            DeleteLastChunk();
        }

        void GenerateChunk()
        {
            Vector3 spawnPosition = new Vector3(
             _nextSpawnX,
             _chunkFirstTransform.position.y,
             _chunkFirstTransform.position.z
         );

            GameObject spawnedChunk = Instantiate(_chunkObject, spawnPosition, Quaternion.identity);

            _spawnedChunks.Add(spawnedChunk);

            _nextSpawnX += 50;
        }

        void DeleteLastChunk()
        {
            if (_spawnedChunks.Count == 0)
                return;

            GameObject lastChunk = _spawnedChunks[0];

            if (lastChunk.transform.position.x < _playerTransform.position.x - 100f)
            {
                Destroy(lastChunk);
                _spawnedChunks.RemoveAt(0);
            }
        }
    }
}
