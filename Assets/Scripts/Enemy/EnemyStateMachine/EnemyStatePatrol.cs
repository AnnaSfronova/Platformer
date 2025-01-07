using UnityEngine;

public class EnemyStatePatrol : EnemyState
{
    private PathPatrol _path;
    private Transform _target;
    private int _currentPoint;
    private float _speed = 1f;
    private string _animation;

    public EnemyStatePatrol(Enemy enemy, IStateMachine stateMachine, PathPatrol path) : base(enemy, stateMachine)
    {
        _path = path;
        _target = _path.GetPointTranform(_currentPoint);
        _animation = Enemy.Animator.Run;
    }

    public override void Enter()
    {        
        Enemy.Animator.PlayAnimation(_animation, true);
    }

    public override void Update()
    {
        TryStop();
        TryChangePoint();
        Move();
    }

    public override void Exit()
    {
        Enemy.Animator.PlayAnimation(_animation, false);
    }

    private void Move()
    {
        Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void TryStop()
    {
        if (Enemy.transform.position == _path.StopPoint.position)
            StateMachine.ChangeState(typeof(EnemyStateIdle));
    }

    private void TryChangePoint()
    {
        if (Enemy.transform.position == _target.position)
        {
            _currentPoint = ++_currentPoint % _path.Length;
            _target = _path.GetPointTranform(_currentPoint);
        }
    }
}
