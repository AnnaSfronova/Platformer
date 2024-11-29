using UnityEngine;

public class EnemyStateChase : EnemyState
{
    private Transform _pointA;
    private Transform _pointB;

    private Player _player;
    private float _speed = 3f;
    private float _height;
    private string _animation;

    public EnemyStateChase(Enemy enemy, Player player, PursueArea area) : base(enemy)
    {
        _player = player;
        _height = _enemy.transform.position.y;
        _pointA = area.PointA;
        _pointB = area.PointB;
        _animation = _enemy.Animator.AnimationRun;
    }

    public override void Enter()
    {
        _enemy.Animator.PlayAnimation(_animation, true);
    }

    public override void Update()
    {
        Move();
    }

    public override void Exit()
    {
        _enemy.Animator.PlayAnimation(_animation, false);
    }

    private void Move()
    {
        if (IsNotStopPoint())
        {
            _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position, _player.transform.position, _speed * Time.deltaTime);
            _enemy.transform.position = new Vector2(_enemy.transform.position.x, _height);
        }
    }

    private bool IsNotStopPoint()
    {
        return _enemy.transform.position.x > _pointA.position.x || _enemy.transform.position.x < _pointB.position.x;
    }
}
