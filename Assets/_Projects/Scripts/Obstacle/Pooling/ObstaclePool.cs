using System.Collections.Generic;
using UnityEngine;
namespace JetpackJoyrideReplica.Obstacles.Pooling
{
    public class ObstaclePool : MonoBehaviour
    {
        [SerializeField] private GameObject _obstaclePrefab;
        private readonly Queue<GameObject> _availableObstacles = new Queue<GameObject>();
        [SerializeField] private int _initalPoolSize = 10;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            PrewarmPool();
        }

        void PrewarmPool()
        {
            for (int i = 0; i < _initalPoolSize; i++)
            {
                GameObject obj = CreateObstacle();
                _availableObstacles.Enqueue(obj);
            }
        }

        private GameObject CreateObstacle()
        {
            GameObject obstacle = Instantiate(_obstaclePrefab, transform);
            obstacle.SetActive(false);
            return obstacle;
        }

        public GameObject Get(Vector3 position, Quaternion rotation)
        {
            GameObject obstacle;

            if (_availableObstacles.Count > 0)
            {
               obstacle = _availableObstacles.Dequeue();
            }
            else
            {
                obstacle = CreateObstacle();
            }

            obstacle.transform.SetPositionAndRotation(position, rotation);
            obstacle.SetActive(true);

            return obstacle;
        }

        public void Return(GameObject obstacle)
        {
            obstacle.SetActive(false);
            _availableObstacles.Enqueue(obstacle);
        }
    }

}
