using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealthPoints;
    [SerializeField] private int _healthPoints;
    [SerializeField] private bool _itsPlayer = false;
    [SerializeField] private GameOwer _gameOwer;

    public int MaxHealthPoints { get { return _maxHealthPoints; } }
    public int HealthPoints { get { return _healthPoints; } }


    private void Awake()
    {
        _healthPoints = _maxHealthPoints;
    }

    public void TakeDamage(int damage)
    {
        _healthPoints -= damage;

        if (_itsPlayer && _healthPoints <= 0)
        {
            _gameOwer.PlayerDead();
        }
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
