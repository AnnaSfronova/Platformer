using UnityEngine;

public class EnemyStateCombat : EnemyState
{
    private Player _player;
    private int _damage = 10;
    private string _animation;
    private float _startTime;
    private float _attackDelay = 0.5f;

    public EnemyStateCombat(Enemy enemy, Player player) : base(enemy)
    {
        _player = player;
        _animation = _enemy.Animator.AnimationAttack;
    }

    public override void Enter()
    {
        _enemy.Animator.PlayAnimation(_animation, true);
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
        _enemy.Animator.PlayAnimation(_animation, false);
    }

    private bool IsTimeAttack()
    {
        return Time.time >= _startTime + _attackDelay;
    }
}
