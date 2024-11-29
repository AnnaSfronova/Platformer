using System;
using UnityEngine;

public class CollisionChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _groundMask;

    private float _radius = 0.6f;

    public Enemy Enemy { get; private set; }

    public event Action<Coin> GatheredCoin;
    public event Action<MedicineKit> GatheredKit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
            GatheredCoin?.Invoke(coin);

        if (collision.gameObject.TryGetComponent(out MedicineKit kit))
            GatheredKit?.Invoke(kit);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            Enemy = enemy;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
            Enemy = null;
    }

    public bool IsGround() =>
        Physics2D.OverlapCircle(transform.position, _radius, _groundMask);
}
