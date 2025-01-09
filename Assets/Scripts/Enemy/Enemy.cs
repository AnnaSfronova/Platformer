using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private EnemyAnimator _animator;

    private float _currentPosition;
    private float _previousPosition;

    public EnemyAnimator Animator => _animator;
    public Health Health => _health;

    private void Awake()
    {
        _currentPosition = transform.position.x;
        _previousPosition = _currentPosition;
    }

    private void OnEnable()
    {
        _health.Changed += Die;
    }

    private void OnDisable()
    {
        _health.Changed -= Die;
    }

    public void TakeDamage(float damage)
    {
        Animator.PlayHit();
        _health.TakeDamage(damage);
    }

    private void Die(float health)
    {
        if (health <= 0)
            gameObject.SetActive(false);
    }
}