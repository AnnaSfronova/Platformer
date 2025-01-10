using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CollisionChecker))]
[RequireComponent(typeof(Health))]
public class Vampirism : MonoBehaviour
{
    private InputReader _input;
    private CollisionChecker _checker;
    private Health _health;
    private Coroutine _coroutine;

    private float _damage;
    private float _power = 50f;
    private bool _isAvailable = true;

    public event Action Activated;
    public event Action Deactivated;

    public float DurationWork { get; private set; }
    public float DurationRecover { get; private set; }
    public float Duration { get; private set; }


    private void OnEnable()
    {
        _input.Vampirism += SetCoroutine;
    }

    private void Awake()
    {
        _input = GetComponent<InputReader>();
        _checker = GetComponent<CollisionChecker>();
        _health = GetComponent<Health>();

        DurationWork = 6f;
        DurationRecover = 4f;
    }

    private void OnDisable()
    {
        _input.Vampirism -= SetCoroutine;
    }

    private void SetCoroutine()
    {
        if (_coroutine != null && _isAvailable)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        if (_isAvailable)
            _coroutine = StartCoroutine(ActivateAbility());
    }

    private IEnumerator ActivateAbility()
    {
        _isAvailable = false;
        Duration = DurationWork;

        Activated?.Invoke();

        while (Duration > 0f)
        {
            TakeHealth();

            Duration -= Time.deltaTime;

            yield return null;
        }

        Deactivated?.Invoke();

        while (Duration < DurationRecover)
        {
            Duration += Time.deltaTime;

            yield return null;
        }

        _isAvailable = true;
    }

    private void TakeHealth()
    {
        if (_checker.GetEnemyInsideCircle().Count <= 0)
            return;

        foreach (Enemy enemy in _checker.GetEnemyInsideCircle())
        {
            if (enemy.Health.Value > 0)
            {
                _damage = _power * Time.deltaTime / DurationWork;

                enemy.TakeDamage(_damage);
                _health.TakeHealth(_damage);
            }
        }
    }
}
