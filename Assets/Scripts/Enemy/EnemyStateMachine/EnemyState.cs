public abstract class EnemyState
{
    protected Enemy Enemy;
    protected IStateMachine StateMachine;

    public EnemyState(Enemy enemy, IStateMachine stateMachine)
    {
        Enemy = enemy;
        StateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
