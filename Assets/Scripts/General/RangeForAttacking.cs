using UnityEngine;

public class RangeForAttacking : MonoBehaviour
{
    [SerializeField] private Health _enemyHealth = null;
    [SerializeField] private int _damage;

    private SpriteRenderer _spriteRenderer;
    private PlayerAnimationSetter _playerAnimationSetter;

    private void Start()
    {
        _spriteRenderer = GetComponentInParent<SpriteRenderer>();
        _playerAnimationSetter = GetComponentInParent<PlayerAnimationSetter>();
    }

    private void Update()
    {
        Vector3 attackDirection = _spriteRenderer.flipX ? Vector3.left : Vector3.right;
        transform.localPosition = attackDirection;

        Attack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _enemyHealth = enemy.GetComponent<Health>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _enemyHealth = null;
        }
    }

    private void Attack()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _playerAnimationSetter.AttackAnimation();

            if (_enemyHealth != null)
            {
                _enemyHealth.TakeDamage(_damage);
                return;
            }
        }
    }
}
