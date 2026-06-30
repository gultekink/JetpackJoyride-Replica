using System.Collections.Generic;
using UnityEngine;
namespace JetpackJoyrideReplica.Level.Pooling
{
    public class ChunkPool : MonoBehaviour
    {
        [SerializeField] private GameObject _chunkPrefab;

        private readonly Queue<GameObject> _availableChunkObject = new Queue<GameObject>();

        [SerializeField] private int _initalPoolSize = 3;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            PreWarmPool();
        }

        void PreWarmPool()
        {
            for (int i = 0; i < _initalPoolSize; i++)
            {
                GameObject chunk = CreateChunk();
                _availableChunkObject.Enqueue(chunk);
            }
        }

        public GameObject CreateChunk()
        {
            GameObject chunk = Instantiate(_chunkPrefab,transform);
            chunk.SetActive(false);
            return chunk;
        }

        public GameObject Get(Vector3 position, Quaternion rotation)
        {
            GameObject chunk;
            if (_availableChunkObject.Count > 0)
            {
                chunk = _availableChunkObject.Dequeue();
            }
            else
            {
                chunk = CreateChunk();
            }
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
