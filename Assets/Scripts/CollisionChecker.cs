using System;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;

    private float _radius = 0.6f;

    public event Action<Coin> Gathered;

    public bool IsGround() =>
        Physics2D.OverlapCircle(transform.position, _radius, _groundMask);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
            Gathered?.Invoke(coin);
    }
}
