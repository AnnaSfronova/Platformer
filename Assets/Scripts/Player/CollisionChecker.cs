using System;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class CollisionChecker : MonoBehaviour
{
    private const string MaskGround = "Ground";

    private Health _health;
    private LayerMask _groundMask;
    private float _radius = 0.6f;

    public Enemy Enemy { get; private set; }

    private void Awake()
    {
        _health = GetComponent<Health>();
        _groundMask = LayerMask.GetMask(MaskGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ICollectable collectable) == false)
            return;

        if (collectable is Coin coin)
        {
            coin.Collect();
        }
        else if (collectable is MedicineKit kit)
        {
            _health.TakeHeal(kit.Heal);
            kit.Collect();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            Enemy = enemy;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            Enemy = null;
    }

    public bool IsGround() =>
        Physics2D.OverlapCircle(transform.position, _radius, _groundMask);
}
