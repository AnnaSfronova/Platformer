using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]
[RequireComponent(typeof(Flipper))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private PathPatrol _path;

    private EnemyState _currentState;

    public EnemyStateIdle StateIdle { get; private set; }
    public EnemyStatePatrol StatePatrol { get; private set; }

    public EnemyAnimator Animator { get; private set; }
    public Flipper Flipper { get; private set; }

    private void Awake()
    {
        Animator = GetComponent<EnemyAnimator>();
        Flipper = GetComponent<Flipper>();
    }

    private void Start()
    {
        StateIdle = new EnemyStateIdle(this);
        StatePatrol = new EnemyStatePatrol(this, _path);

        _currentState = StatePatrol;
        _currentState.Enter();
    }

    private void Update()
    {
        _currentState.Update();
    }

    public void SetState(EnemyState state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
}