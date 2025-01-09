using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class CollisionChecker : MonoBehaviour
{
    private const string MaskGround = "Ground";
    private const string MaskEnemy = "Enemy";

    private Health _health;
    private LayerMask _maskGround;
    private LayerMask _maskEnemy;
    private float _radiusGround = 0.6f;
    private float _radiusAbility = 3f;

    public Enemy Enemy { get; private set; }

    private void Awake()
    {
        _health = GetComponent<Health>();
        _maskGround = LayerMask.GetMask(MaskGround);
        _maskEnemy = LayerMask.GetMask(MaskEnemy);
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
            _health.TakeHealth(kit.Heal);
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

    public List<Enemy> GetEnemyInsideCircle()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radiusAbility, _maskEnemy);

        List<Enemy> enemies = colliders.Select(enemy => enemy.GetComponent<Enemy>()).Where(enemy => enemy != null).ToList();

        return enemies;
    }

    public bool IsGround() =>
        Physics2D.OverlapCircle(transform.position, _radiusGround, _maskGround);
}
