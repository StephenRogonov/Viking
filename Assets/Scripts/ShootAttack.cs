using UnityEngine;
using UnityEngine.Events;

//������ ������������� �����
public class ShootAttack : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _firePoint;

    private Animator _anim;

    public UnityEvent OnRangeAttackEnd;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void StartShooting()
    {
       _anim.SetBool("isShooting", true);
    }

    public void Shoot()
    {
        //�� ������� ������ �������� (������ ������ ����) �������� ������ � ����� �����, ������������ ������������ ��������
        //���������
        GameObject projectile = Instantiate(_projectile, _firePoint.position, _firePoint.rotation);
    }

    //�� ��������� ����� �������� ����� ���������� �������� �� ��� X
    public void EndShooting()
    {
        _anim.SetBool("isShooting", false);
        OnRangeAttackEnd.Invoke();
    }
}
