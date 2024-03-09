using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event Action Changed;

    private float _currentHealth;

    public float MaxHealth => _maxHealth;

    public float CurrentHealth => _currentHealth;

    private void Awake() => _currentHealth = MaxHealth;

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        Changed?.Invoke();
    }

    public void Heal(float heal)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + heal, 0, _maxHealth);
        Changed?.Invoke();
    }
}
