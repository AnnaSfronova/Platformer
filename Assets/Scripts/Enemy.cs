using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
[RequireComponent(typeof(EnemyAnimator))]
[RequireComponent(typeof(EnemyTarget))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyMover _enemyMover;
    [SerializeField] private EnemyAnimator _enemyAnimator;
    [SerializeField] private EnemyTarget _enemyTarget;

    private void FixedUpdate()
    {
        TryChangeTarget();
        TryFlip();

        _enemyMover.Move(_enemyTarget.Target);
    }

    private void TryChangeTarget()
    {
        if (transform.position == _enemyTarget.Target.position)
            _enemyTarget.ChangePoint();
    }

    private void TryFlip()
    {
        if (transform.position.x > _enemyTarget.Target.position.x)
            _enemyAnimator.Flip(true);

        else
            _enemyAnimator.Flip(false);
    }
}