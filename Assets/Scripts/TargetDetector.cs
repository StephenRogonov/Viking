using UnityEngine;

//C����� ��� ��������� �����, ����� ����� ��������� � ������� ���������
public class TargetDetector : MonoBehaviour
{
    private SkeletonBossController _bossController;

    private void Awake()
    {
        _bossController = GetComponentInParent<SkeletonBossController>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _bossController._currentState = 3;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _bossController._currentState = 1;            
        }
    }
}
