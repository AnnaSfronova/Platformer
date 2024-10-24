using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Released;

    public void Init(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void ReturnToPool()
    {
        Released?.Invoke(this);
    }
}
