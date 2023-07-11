using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float _climbSpeed;
    [SerializeField] private bool _isGrounded = false;

    [Header("Settings")]
    [SerializeField] private Transform _colliderTransform;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpOffset;
    [SerializeField] private float _playerGravity;

    public Collider2D _ladderTopCollider;

    private Rigidbody2D _rb;
    private Animator _anim;
    public bool onLadder;
    public float ladderX;
    private bool _facingRight = true;
    public bool _canMove = true;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = _playerGravity;
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = _colliderTransform.position;
        _isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, _jumpOffset, _groundMask);

        //≈сли игрок не на земле и не на лестнице, у него всегда должна проигрыватьс€ анимаци€ прыжка
        if (!_isGrounded && !onLadder)
        {
            _anim.SetBool("isJumping", true);
            _anim.SetFloat("yVelocity", _rb.velocity.y);
        }
        else
        {
            _anim.SetBool("isJumping", false);
        }
    }

    public void CanMove()
    {
        _canMove = true;
    }

    public void HorizontalMove(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
        {
            Jump();
        }

        if (direction != 0 && _canMove)
        {
            HorizontalMovement(direction);
            _anim.SetBool("isWalking", true);
            if (direction > 0 && !_facingRight)
            {
                Flip();
            }
            else if (direction < 0 && _facingRight)
            {
                Flip();
            }
        }
        else
        {
            _anim.SetBool("isWalking", false);
        }
    }

    //ѕереворот персонажа на 180 по оси y, дл€ того, чтобы он стрел€л в том направлении, куда смотрит
    private void Flip()
    {
        _facingRight = !_facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
        }
    }

    private void HorizontalMovement(float direction)
    {
        _rb.velocity = new Vector2(direction * _playerSpeed, _rb.velocity.y);
    }

    public void LadderMovement(float direction)
    {
        if (onLadder)
        {
            if (_isGrounded)
            {
                _anim.SetBool("isClimbing", false);
                _rb.gravityScale = _playerGravity;
                if (direction != 0)
                {
                    //ѕри нажатии кнопки движени€ вдоль оси Y выключаем верхний коллайдер лестницы
                    _ladderTopCollider.enabled = false;
                    _rb.gravityScale = 0f;
                    _rb.velocity = new Vector2(_rb.velocity.x, direction * _climbSpeed);
                }
            }
            else if (!_isGrounded)
            {
                _anim.SetBool("isClimbing", true);
                //«десь гравитаци€ становитс€ равна 0 если игрок попал на лестницу не с земли (например во врем€ прыжка)
                _rb.gravityScale = 0f;
                if (direction != 0)
                {
                    _rb.velocity = new Vector2(0, direction * _climbSpeed);
                    //÷ентрируем игрока относительно лестницы, когда он движетс€ по ней вверх или вниз
                    transform.position = new Vector2(ladderX, transform.position.y);
                    _anim.speed = 1;
                }
                else
                {
                    _rb.velocity = new Vector2(0, 0);
                    //≈сли игрок останавливаетс€ во врем€ движени€ по лестнице, то анимаци€ лазань€ ставитс€ на паузу
                    _anim.speed = 0;
                }
            }
        }

        if (!onLadder)
        {
            _rb.gravityScale = _playerGravity;
            _anim.speed = 1;
            _ladderTopCollider.enabled = true;
            _anim.SetBool("isClimbing", false);
        }
    }
}
