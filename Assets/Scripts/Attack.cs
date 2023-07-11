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

    //�������� ������� ��������� ����� � ����������� ����� �������� ����� � ������� ������� ��������
    public void DoAttack()
    {
        //������ ����������� ����������. ��� ����������, ������� ��������� �� ����������� ����,
        //������������ ��� ���������� ����������� � ������
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRadius, _enemies);

        //��� ������� ���������� �� ������� ���������� ������� ��������� �����
        foreach (Collider2D enemyGameObject in enemies)
        {
            enemyGameObject.GetComponent<HealthCount>().TakeDamage(_damage);
        }
    }

    //������ ���������� ��� ����������� ������������� ������� ���������
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRadius);
    }

    //� ����� �������� ����� ��������� �������� ����� � �������� ������� ��������� �����, ����� �������� ����� ��� ���������.
    public void EndAttack()
    {
        OnAttackEnd.Invoke();
        _anim.SetBool("isAttacking", false);
    }
}
