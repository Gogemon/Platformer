using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealthPoints;
    [SerializeField] private int _healthPoints;

    public int HealthPoints { get { return _healthPoints; } }

    private void Start()
    {
        _healthPoints = _maxHealthPoints;
    }

    public void TakeDamage(int damage)
    {
        _healthPoints -= damage;
    }

    public void TakeHill(int health)
    {
        _healthPoints += health;

        if (_healthPoints > _maxHealthPoints)
        {
            _healthPoints = _maxHealthPoints;
        }
    }
}
