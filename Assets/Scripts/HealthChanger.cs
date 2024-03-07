using UnityEngine;
using UnityEngine.UI;

public class HealthChanger : HealthUIElement
{
    [SerializeField] private Slider _healthSlider;

    private void UpDateHealthUI(float health)
    {
        if (_healthSlider != null)
        {
            _healthSlider.value = health;
            _healthSlider.maxValue = MaxHealth;
        }
    }

    protected override void HealthChanged(float targetValue) => _health.Changed += UpDateHealthUI; 

}
