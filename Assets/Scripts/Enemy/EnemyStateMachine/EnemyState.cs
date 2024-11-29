public abstract class EnemyState
{
    protected Enemy _enemy;

    public EnemyState(Enemy enemy)
    {
        _enemy = enemy;
    }
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
