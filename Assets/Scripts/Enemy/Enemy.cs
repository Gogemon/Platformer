using UnityEngine;

[RequireComponent(typeof(LootSpawner))]
[RequireComponent(typeof(Health))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject[] _loot;
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private float _speed;

    private LootSpawner _lootSpawner;
    private Health _health;
    private int _currentPointNumber = 0;
    private float _minimalDistance = 0.01f;

    private void Start()
    {
        _lootSpawner = GetComponent<LootSpawner>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (_patrolPoints.Length == 0)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, _patrolPoints[_currentPointNumber].position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _patrolPoints[_currentPointNumber].position) < _minimalDistance)
        {
            _currentPointNumber++;
        }

        if (_currentPointNumber > _patrolPoints.Length - 1)
        {
            _currentPointNumber = 0;
        }

        if (_health.HealthPoints <= 0)
        {
            _lootSpawner.Spawn(_loot[Random.Range(0, _loot.Length - 1)]);
            gameObject.SetActive(false);
        }
    }
}
