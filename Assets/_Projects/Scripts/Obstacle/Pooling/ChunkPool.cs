using System.Collections.Generic;
using UnityEngine;

namespace JetpackJoyrideReplica.Level.Pooling
{
    public class ChunkPool : MonoBehaviour
    {
        [SerializeField] private GameObject _chunkPrefab;

        [SerializeField] private int _initalPoolSize = 3;

        private readonly Queue<GameObject> _availableChunkObject = new();

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Awake()
        {
            PreWarmPool();
        }

        private void PreWarmPool()
        {
            for (var i = 0; i < _initalPoolSize; i++)
            {
                var chunk = CreateChunk();
                _availableChunkObject.Enqueue(chunk);
            }
        }

        public GameObject CreateChunk()
        {
            var chunk = Instantiate(_chunkPrefab, transform);
            chunk.SetActive(false);
            return chunk;
        }

        public GameObject Get(Vector3 position, Quaternion rotation)
        {
            GameObject chunk;
            if (_availableChunkObject.Count > 0)
                chunk = _availableChunkObject.Dequeue();
            else
                chunk = CreateChunk();
            chunk.transform.SetPositionAndRotation(position, rotation);
            chunk.SetActive(true);
            return chunk;
        }

        public void Return(GameObject obj)
        {
            obj.SetActive(false);
            _availableChunkObject.Enqueue(obj);
        }
    }
}