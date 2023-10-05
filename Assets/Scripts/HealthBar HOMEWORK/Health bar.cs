using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private int _valueButtons = 10;

    private Health _health;
    private Coroutine _coroutine;

    private void Start()
    {
        _health = GetComponent<Health>();
        _slider.maxValue = _health.HealthPoints;
        UpdateHealthBar();
    }
    
    public void ClickOnHillButton()
    {
        _health.TakeHill(_valueButtons);
        UpdateHealthBar();

    }

    public void ClickOnDamageButton()
    {
        _health.TakeDamage(_valueButtons);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeBarValue());
    }

    private IEnumerator ChangeBarValue()
    {

        while (true)
        {
            _slider.value = Mathf.Lerp(_slider.value, _health.HealthPoints, _duration * Time.deltaTime);
            
            yield return null;
        }
    }
}