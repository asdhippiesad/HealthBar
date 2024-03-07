using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthUIElement
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

    private void Awake()
    {
        _healthSlider.maxValue = MaxHealth;
        _healthSlider.value = CurrentHealth;
    }

    protected override void HealthChanged(float healthNormalized)
    {
        _healthSlider.value = healthNormalized;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SetHealth(healthNormalized));
    }

    private IEnumerator SetHealth(float targetValue)
    {
        targetValue = CurrentHealth;

        while (_healthSlider.value > targetValue)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, targetValue, _speed * Time.deltaTime);
            yield return null;
        }

        _healthSlider.value = targetValue;
    }
}