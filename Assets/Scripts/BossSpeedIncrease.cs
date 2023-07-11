using UnityEngine;

//������ ��� ��������� �������� ����� � ����������� ���������, ����� �� (��������) ��������� �� �����.
//������ ����� �� ��������� ���������� � ������� ������� � ������
public class BossSpeedIncrease : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
    [SerializeField] private float _speedIncrease; //����������� ���������� ��������
    private SkeletonBossController _bossController;

    private void Awake()
    {
        _bossController = _boss.GetComponent<SkeletonBossController>();
    }

    //� ������ ��������� ������ � ��������� �������� �������� �������� ����� �� �������� �����������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _bossController._speed *= _speedIncrease;
        }
    }

    //���� ����� ��������� � ���������� �� ����� ���� ������ ������ "��������" �� ���������
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            Vector3 scale = _bossController.transform.localScale;
            if (collision.transform.position.x > _bossController.transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * -1;
            }
            else
            {
                scale.x = Mathf.Abs(scale.x);
            }
            _bossController.transform.localScale = scale;
        }
    }

    //���� ����� ������� ���������, �������� ����� ������������ � ��������� ��������
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _bossController._speed /= _speedIncrease;
        }
    }
}
