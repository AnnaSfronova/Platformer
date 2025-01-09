using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Vampirism _ability;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _ability.Activated += SpendAbility;
        _ability.Deactivated += RecoverAbility;
    }

    private void OnDisable()
    {
        _ability.Activated -= SpendAbility;
        _ability.Deactivated -= RecoverAbility;
    }

    private void SpendAbility()
    {
        SetCoroutine(_slider.minValue, _ability.DurationWork);
    }

    private void RecoverAbility()
    {
        SetCoroutine(_slider.maxValue, _ability.DurationRecover);
    }

    private void SetCoroutine(float value, float duration)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        _coroutine = StartCoroutine(PrintAbility(value, duration));
    }

    private IEnumerator PrintAbility(float value, float duration)
    {
        while (_slider.value != value)
        {            
            _slider.value = _ability.Duration / duration;
            yield return null;
        }
    }
}
