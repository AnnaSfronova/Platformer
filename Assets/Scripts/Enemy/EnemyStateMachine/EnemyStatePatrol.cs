using UnityEngine;

public class EnemyStatePatrol : EnemyState
{
    private PathPatrol _path;
    private Transform _target;
    private int _currentPoint;
    private float _speed = 1f;
    private string _animation;

    public EnemyStatePatrol(Enemy enemy, PathPatrol path) : base(enemy)
    {
        _path = path;
        _target = _path.GetPointTranform(_currentPoint);
        _animation = _enemy.Animator.AnimationRun;
    }

    public override void Enter()
    {        
        _enemy.Animator.PlayAnimation(_animation, true);
    }

    public override void Update()
    {
        TryStop();
        TryChangePoint();
        Move();
    }

    public override void Exit()
    {
        _enemy.Animator.PlayAnimation(_animation, false);
    }

    private void Move()
    {
        _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void TryStop()
    {
        if (_enemy.transform.position == _path.StopPoint.position)
            _enemy.StateMachine.SetState(_enemy.StateMachine.StateIdle);
    }

    private void TryChangePoint()
    {
        if (_enemy.transform.position == _target.position)
        {
            _currentPoint = ++_currentPoint % _path.Length;
            _target = _path.GetPointTranform(_currentPoint);
        }
    }
}
