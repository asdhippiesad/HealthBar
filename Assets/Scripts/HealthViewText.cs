using TMPro;
using UnityEngine;

public class HealthViewText : HealthUIElement
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start() => HealthChanged(MaxHealth);

    protected override void HealthChanged(float current) => _text.text = $"{current}/ {MaxHealth}";
}
