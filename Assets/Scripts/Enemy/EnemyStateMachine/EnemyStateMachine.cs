using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private PathPatrol _path;
    [SerializeField] private PursueArea _area;

    private EnemyState _currentState;

    public EnemyStateIdle StateIdle { get; private set; }
    public EnemyStatePatrol StatePatrol { get; private set; }

    private void Start()
    {
        StateIdle = new EnemyStateIdle(_enemy);
        StatePatrol = new EnemyStatePatrol(_enemy, _path);

        _currentState = StatePatrol;
        _currentState.Enter();

        _area.IntruderIn += SetStateChase;
        _area.IntruderOut += SetStatePatrol;
    }

    private void OnDisable()
    {
        _area.IntruderIn -= SetStateChase;
        _area.IntruderOut -= SetStatePatrol;
    }

    private void Update()
    {
        _currentState.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            SetState(new EnemyStateCombat(_enemy, player));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player) && _area.HasPlayer)
            SetStateChase(player);
        else
            SetStatePatrol();
    }

    public void SetState(EnemyState state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    private void SetStateChase(Player player)
    {
        SetState(new EnemyStateChase(_enemy, player, _area));
    }

    private void SetStatePatrol()
    {
        SetState(StatePatrol);
    }
}
