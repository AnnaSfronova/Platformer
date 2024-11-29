using UnityEngine;

[RequireComponent(typeof(EnemyStateMachine))]
[RequireComponent(typeof(EnemyAnimator))]
[RequireComponent(typeof(Flipper))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;

    private float _currentPosition;
    private float _previousPosition;

    public EnemyStateMachine StateMachine { get; private set; }
    public EnemyAnimator Animator { get; private set; }

    private void Awake()
    {
        StateMachine = GetComponent<EnemyStateMachine>();
        Animator = GetComponent<EnemyAnimator>();

        _currentPosition = transform.position.x;
        _previousPosition = _currentPosition;

        _health.Died += Die;
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}