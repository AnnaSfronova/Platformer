using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> CoinRelease;

    public void Init(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
            CoinRelease?.Invoke(this);
    }
}
