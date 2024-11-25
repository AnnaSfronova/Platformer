using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;

    private ObjectPool<Coin> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (coin) => OnGet(coin),
            actionOnRelease: (coin) => coin.gameObject.SetActive(false),
            defaultCapacity: 5,
            maxSize: 5
            );
    }

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private void OnGet(Coin coin)
    {
        coin.Released += OnRelease;
        coin.Init(transform.position);
    }

    private void OnRelease(Coin coin)
    {
        coin.Released -= OnRelease;
        _pool.Release(coin);
    }

    private IEnumerator Spawn()
    {
        float delay = 5f;

        WaitForSeconds wait = new(delay);

        while (enabled)
        {
            _pool.Get();
            yield return wait;
        }
    }
}
