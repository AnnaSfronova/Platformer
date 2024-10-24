using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyTarget))]
[RequireComponent(typeof(EnemyAnimator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _mover;
    [SerializeField] private EnemyTarget _target;
    [SerializeField] private EnemyAnimator _animator;

    private void FixedUpdate()
    {
        TryChangeTarget();
        TryFlip();

        _mover.Move(_target.Target);
    }

    private void TryChangeTarget()
    {
        if (transform.position == _target.Target.position)
            _target.ChangePoint();
    }

    private void TryFlip()
    {
        _animator.Flip(transform.position.x > _target.Target.position.x);
    }
}