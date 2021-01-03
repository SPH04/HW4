using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;

    public int Health => _health;
    public int MaxHealth => _maxHealth;

    private void Start()
    {
        if (_health < 0 || _health > _maxHealth)
            throw new ArgumentException(nameof(_health));
    }

    public void ApplyDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentException(nameof(damage));

        _health -= damage > _health ? _health : damage;
    }
    public void ApplyHeal(int heal)
    {
        if (heal < 0)
            throw new ArgumentException(nameof(heal));

        _health += heal + _health > _maxHealth ? _maxHealth - _health : heal;
    }
}
