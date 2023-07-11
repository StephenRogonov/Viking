using UnityEngine;
using UnityEngine.Events;

//”ниверсальный скрипт подсчЄта HP
public class HealthCount : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    public UnityEvent OnDeath;
    public UnityEvent<float> OnHealthChange;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        SendRemainingPercentage(_currentHealth / _maxHealth);
        IsDeadCheck();
    }

    private void SendRemainingPercentage(float health)
    {
        OnHealthChange.Invoke(health);
    }

    public void IsDeadCheck()
    {
        if (_currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
    }
}
