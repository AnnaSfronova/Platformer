using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private CollisionChecker _checker;
    [SerializeField] private Health _health;

    private int _damage = 10;

    private void OnEnable()
    {
        _input.Attacked += TryAttack;
        _health.Changed += Die;
    }

    private void OnDisable()
    {
        _input.Attacked -= TryAttack;
        _health.Changed -= Die;
    }

    public void TakeDamage(float damage)
    {
        _animator.PlayHit();
        _health.TakeDamage(damage);
    }

    private void TryAttack()
    {
        _animator.PlayAttack();

        if (_checker.Enemy != null && _checker.IsGround())
        {
            Enemy enemy = _checker.Enemy;
            enemy.TakeDamage(_damage);
        }
    }

    private void Die(float health)
    {
        if (health <= 0)
            gameObject.SetActive(false);
    }
}
