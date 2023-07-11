using UnityEngine;

//������ ������������ ������ �� ������ ��� ������� � ������ � ����� ������
public class CinemachineCameraSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
    public Collider2D[] _bossFightConfiners;
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            //�������� ��������, ������� ������ ��������� �� ������ ������
            _anim.Play("BossFightCamera");
            //�������� ���������� �������������� ������������ ����� �� ��������� �������
            foreach (Collider2D confiner in _bossFightConfiners)
            {
                confiner.enabled = true; 
            }
            //�������� ������ �������� �����. ��� ������� ���� ���� �� ��������� ���� ����� �� ����� � ����� �������
            _boss.GetComponent<SkeletonBossController>().enabled = true;
        }
    }
}
