using System.Collections.Generic;
using JetpackJoyrideReplica.Collectibles;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private int _initialPoolSize = 20;

    private readonly Queue<Coin> _pool = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        PrewarmPool();
    }

    private void PrewarmPool()
    {
        for (var i = 0; i < _initialPoolSize; i++)
        {
            var coin = CreateCoin();
            Return(coin);
        }
    }

    private Coin CreateCoin()
    {
        var coin = Instantiate(_coinPrefab, transform);
        coin.Collected += Return;
        return coin;
    }

    public Coin Get(Vector2 position, Quaternion rotation)
    {
        var coin = _pool.Count > 0 ? _pool.Dequeue() : CreateCoin();

        coin.transform.SetLocalPositionAndRotation(position, rotation);
        coin.gameObject.SetActive(true);
        return coin;
    }

    public void Return(Coin coin)
    {
        coin.gameObject.SetActive(false);
        _pool.Enqueue(coin);
    }
}