using UnityEngine;

public class EnemyStateIdle : EnemyState
{
    private float _startTime;
    private float _idleTime = 2f;

    public EnemyStateIdle(Enemy enemy, IStateMachine stateMachine) : base(enemy, stateMachine) { }

    public override void Enter()
    {
        _startTime = Time.time;
    }

    public override void Update()
    {
        TryFinish();
    }

    private void TryFinish()
    {
        if (Time.time >= _startTime + _idleTime)
            StateMachine.ChangeState(typeof(EnemyStatePatrol));
    }
}
