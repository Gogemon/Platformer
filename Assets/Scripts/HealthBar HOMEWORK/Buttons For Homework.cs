using UnityEngine;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(HealthBar))]

public class ButtonsForHomework : MonoBehaviour
{
    [SerializeField] private int _valueButtons = 10;

    private Health _health;
    private HealthBar _healthBar;

    void Start()
    {
        _health = GetComponent<Health>();
        _healthBar = GetComponent<HealthBar>();
    }

    public void ClickOnHillButton()
    {
        _health.TakeHill(_valueButtons);
        _healthBar.UpdateHealthBar();

    }

    public void ClickOnDamageButton()
    {
        _health.TakeDamage(_valueButtons);
        _healthBar.UpdateHealthBar();
    }
}
