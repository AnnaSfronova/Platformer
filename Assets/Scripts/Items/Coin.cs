using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public event Action<Coin> Released;

    public void Init(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void Collect()
    {
        Released?.Invoke(this);
    }
}
