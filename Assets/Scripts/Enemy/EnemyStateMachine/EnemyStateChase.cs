using UnityEngine;

public class EnemyStateChase : EnemyState
{
    private Transform _pointA;
    private Transform _pointB;

    private Player _player;
    private float _speed = 3f;
    private float _height;
    private string _animation;

    public EnemyStateChase(Enemy enemy, IStateMachine stateMachine, Player player, PursueArea area) : base(enemy, stateMachine)
    {
        _player = player;
        _height = Enemy.transform.position.y;
        _pointA = area.PointA;
        _pointB = area.PointB;
        _animation = Enemy.Animator.Run;
    }

    public override void Enter()
    {
        Enemy.Animator.PlayAnimation(_animation, true);
    }

    public override void Update()
    {
        Move();
    }

    public override void Exit()
    {
        Enemy.Animator.PlayAnimation(_animation, false);
    }

    private void Move()
    {
        if (IsNotStopPoint())
        {
            Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, _player.transform.position, _speed * Time.deltaTime);
            Enemy.transform.position = new Vector2(Enemy.transform.position.x, _height);
        }
    }

    private bool IsNotStopPoint()
    {
        return Enemy.transform.position.x > _pointA.position.x && Enemy.transform.position.x < _pointB.position.x;
    }
}
