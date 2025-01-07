using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;

    public event Action<int> Changed;

    public int Value { get; private set; }
    public int MaxValue => _maxValue;

    private void Awake()
    {
        Value = _maxValue;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            return;

        Value = Mathf.Clamp(Value - damage, 0, _maxValue);
        Changed?.Invoke(Value);
    }

    public void TakeHeal(int heal)
    {
        if (heal < 0)
            return;

        Value = Mathf.Clamp(Value + heal, 0, _maxValue);
        Changed?.Invoke(Value);
    }
}