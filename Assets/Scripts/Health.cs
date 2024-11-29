using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    public event Action Died;

    private int _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log(_health);

        if (_health <= 0)
        {
            _health = 0;
            Died?.Invoke();
        }
    }

    public void TakeHeal(int heal)
    {
        _health += heal;
        ClampHeal();
        Debug.Log(_health);
    }

    private void ClampHeal()
    {
        if (_health > _maxHealth)
            _health = _maxHealth;
    }
}
