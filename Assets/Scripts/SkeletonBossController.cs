using UnityEngine;

//Скрипт для движения противника
public class SkeletonBossController : MonoBehaviour
{
    [SerializeField] private float _timeToRevert;

    private Rigidbody2D _rb;
    private Animator _anim;
    private Attack _attack;
    private Vector3 _scale;

    private float _currentTimeToRevert;
    public float _speed;
    public float _currentState;

    private const float IdleState = 0;
    private const float WalkingState = 1;
    private const float RevertState = 2;
    private const float AttackState = 3;

    private void Awake()
    {
        _currentTimeToRevert = 0;
        _currentState = WalkingState;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _attack = GetComponent<Attack>();
    }

    private void Update()
    {
        if (_currentTimeToRevert >= _timeToRevert)
        {
            _currentTimeToRevert = 0;
            _currentState = RevertState;
        }

        switch (_currentState)
        {
            //Режим патрулирования (когда игрок не на платформе, на которой находится босс)
            case IdleState:
                //Ждёт в крайней точке сцены заданное время
                _currentTimeToRevert += Time.deltaTime;
                break;
            case WalkingState:
                _anim.SetBool("isAttacking", false);
                _scale = transform.localScale;
                //Направление движения определяется направлением спрайта
                if (_scale.x > 0)
                {
                    _rb.velocity = Vector2.left * _speed * 1;
                }
                else
                {
                    _rb.velocity = Vector2.left * _speed * -1;
                }
                break;
            case RevertState:
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
                _currentState = WalkingState;
                break;
            case AttackState:
                _attack.StartAttack();
                break;
        }

        _anim.SetFloat("velocity", _rb.velocity.magnitude);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyConfiner"))
        {
            _currentState = IdleState;
        }
    }
}
