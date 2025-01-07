using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private EnemyAnimator _animator;

    private float _currentPosition;
    private float _previousPosition;

    public EnemyAnimator Animator => _animator;

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

    public void TakeDamage(int damage)
    {
        Animator.PlayTriggerAnimation(Animator.Hit);
        _health.TakeDamage(damage);
    }

    private void Die(int health)
    {
        if (health <= 0)
            gameObject.SetActive(false);
    }
}