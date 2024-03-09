using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthUIElement
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _speed;

    private Coroutine _coroutine;

    private void OnEnable() => _health.Changed += HealthChanged;

    protected override void HealthChanged()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SetHealth());
    }

    private IEnumerator SetHealth()
    {
        float initialValue = _healthSlider.value;

        while (!Mathf.Approximately(_healthSlider.value, CurrentHealth))
        {
            initialValue = Mathf.MoveTowards(initialValue, CurrentHealth, _speed * Time.deltaTime);
            _healthSlider.value = initialValue;
            yield return null;
        }

        _healthSlider.value = CurrentHealth;
    }
}