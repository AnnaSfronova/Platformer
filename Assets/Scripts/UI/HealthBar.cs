using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private Coroutine _coroutine;
    private float _speed = 0.2f;

    private void OnEnable()
    {
        _health.Changed += PrintHealth;

        _slider.maxValue = _health.MaxValue;
        _slider.value = _health.MaxValue;
    }

    private void OnDisable()
    {
        _health.Changed -= PrintHealth;
        _coroutine = null;
    }

    protected void PrintHealth(int health)
    {
        SetCoroutine(health);
    }

    private void SetCoroutine(int health)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        if (_health.Value > 0)
            _coroutine = StartCoroutine(PrintHealthSmooth(health));
    }

    private IEnumerator PrintHealthSmooth(int health)
    {
        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _speed);

            yield return null;
        }
    }
}
