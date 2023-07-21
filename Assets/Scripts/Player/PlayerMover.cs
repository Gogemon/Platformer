using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerAnimationSetter))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetection))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _shiftedSpeedMultiplier;
    [SerializeField] private float _jumpForce;

    private SpriteRenderer _playerBody;
    private PlayerAnimationSetter _playerAnimationSetter;
    private Rigidbody2D _rigidbody2D;
    private GroundDetection _groundDetection;

    private void Start()
    {
        _playerBody = GetComponent<SpriteRenderer>();
        _playerAnimationSetter = GetComponent<PlayerAnimationSetter>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _groundDetection = GetComponent<GroundDetection>();
    }

    private void Update()
    {
        Moove();
        Jump();
    }

    private void Moove()
    {
        const int StayAnimation = 0;
        const int WalkAnimation = 1;
        const int RunAnimation = 2;

        bool isMoving = false;
        float moveDirection = 0;
        float moveSpeed;

        if (Input.GetKey(KeyCode.D))
        {
            _playerBody.flipX = false;
            isMoving = true;
            moveDirection = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _playerBody.flipX = true;
            isMoving = true;
            moveDirection = -1;
        }

        moveSpeed = isMoving ? (_speed * (Input.GetKey(KeyCode.LeftShift) ? _shiftedSpeedMultiplier : WalkAnimation)) : StayAnimation;
        transform.Translate(moveSpeed * Time.deltaTime * moveDirection, 0, 0);
        _playerAnimationSetter.MuveAnimations(isMoving ? (Input.GetKey(KeyCode.LeftShift) ? RunAnimation : WalkAnimation) : StayAnimation);
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _groundDetection.IsGround)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
        }
    }
}
