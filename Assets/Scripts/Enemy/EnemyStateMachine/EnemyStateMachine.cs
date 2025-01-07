using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour, IStateMachine
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Player _player;
    [SerializeField] private PathPatrol _path;
    [SerializeField] private PursueArea _area;

    private Dictionary<Type, EnemyState> _states = new();
    private EnemyState _currentState;

    private void Start()
    {
        _states.Add(typeof(EnemyStateIdle), new EnemyStateIdle(_enemy, this));
        _states.Add(typeof(EnemyStatePatrol), new EnemyStatePatrol(_enemy, this, _path));
        _states.Add(typeof(EnemyStateChase), new EnemyStateChase(_enemy, this, _player, _area));
        _states.Add(typeof(EnemyStateCombat), new EnemyStateCombat(_enemy, this, _player));

        _states.TryGetValue(typeof(EnemyStatePatrol), out _currentState);
        _currentState.Enter();

        _area.IntruderIn += ChangeState;
        _area.IntruderOut += ChangeState;
    }

    private void OnDisable()
    {
        _area.IntruderIn -= ChangeState;
        _area.IntruderOut -= ChangeState;
    }

    private void Update()
    {
        _currentState.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
            ChangeState(typeof(EnemyStateCombat));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _) && _area.HasPlayer)
            ChangeState(typeof(EnemyStateChase));
        else
            ChangeState(typeof(EnemyStatePatrol));
    }

    public void ChangeState(Type type)
    {
        _currentState.Exit();
        _currentState = _states[type];
        _currentState.Enter();
    }
}
