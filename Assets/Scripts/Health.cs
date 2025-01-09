using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;

    public event Action<float> Changed;

    public float Value { get; private set; }
    public float MaxValue => _maxValue;

    private void Awake()
    {
        Value = _maxValue;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        Value = Mathf.Clamp(Value - damage, 0, _maxValue);
        Changed?.Invoke(Value);
    }

    public void TakeHealth(float heal)
    {
        if (heal < 0)
            return;

        Value = Mathf.Clamp(Value + heal, 0, _maxValue);
        Changed?.Invoke(Value);
    }
}