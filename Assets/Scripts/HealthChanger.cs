using UnityEngine;
using UnityEngine.UI;

public class HealthChanger : HealthUIElement
{
    [SerializeField] private Slider _healthSlider;

    private void UpDateHealthUI()
    {
        if (_healthSlider != null)
        {
            _healthSlider.value = CurrentHealth;
            _healthSlider.maxValue = MaxHealth;
        }
    }

    protected override void HealthChanged() => _health.Changed += UpDateHealthUI; 
}
