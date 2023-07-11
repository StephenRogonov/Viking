using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemies;
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRadius;
    private Animator _anim;

    public UnityEvent OnAttackEnd;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void StartAttack()
    {
        _anim.SetBool("isAttacking", true);
    }

    //Вызываем функцию нанесения урона в определённом кадре анимации атаки с помощью события анимации
    public void DoAttack()
    {
        //Создаём виртуальную окружность. Все коллайдеры, которые находятся на определённом слое,
        //пересекающие эту окружность добавляются в массив
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _enemies);

        //Для каждого коллайдера из массива вызывается функция получения урона
        foreach (Collider2D enemyGameObject in enemies)
        {
            enemyGameObject.GetComponent<HealthCount>().TakeDamage(_damage);
        }
    }

    //Рисуем окружность для визуального представления радиуса поражения
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
    }

    //В конце анимации атаки выключаем анимацию атаки и вызываем событие окончания атаки, чтобы персонаж снова мог двигаться.
    public void EndAttack()
    {
        OnAttackEnd.Invoke();
        _anim.SetBool("isAttacking", false);
    }
}
