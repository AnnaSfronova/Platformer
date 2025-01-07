using UnityEngine;

public class EnemyStateCombat : EnemyState
{
    private Player _player;
    private int _damage = 10;
    private string _animation;
    private float _startTime;
    private float _attackDelay = 0.5f;

    public EnemyStateCombat(Enemy enemy, IStateMachine stateMachine, Player player) : base(enemy, stateMachine)
    {
        _player = player;
        _animation = Enemy.Animator.Attack;
    }

    public override void Enter()
    {
        Enemy.Animator.PlayAnimation(_animation, true);
        _startTime = Time.time;
    }

    public override void Update()
    {
        if (IsTimeAttack())
        {
            _player.TakeDamage(_damage);
            _startTime = Time.time;
        }
    }

    public override void Exit()
    {
        Enemy.Animator.PlayAnimation(_animation, false);
    }

    private bool IsTimeAttack()
    {
        return Time.time >= _startTime + _attackDelay;
    }
}
