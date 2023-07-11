using UnityEngine;

//������ ��� ����������� ���������, ����� ����� ��������� �� ��������
public class LadderDetector : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    [SerializeField] private Collider2D _topCollider;

    private void Awake()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            //����� ����� ������ �� ��������, ��� ��������� ���������� ����������� �� ����� ��������,
            //������� �����������, ����� ����� �������� �������� ����� ��� ����
            _playerMovement._ladderTopCollider = _topCollider;
            _playerMovement.onLadder = true;
            _playerMovement.ladderX = gameObject.transform.position.x;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _playerMovement.onLadder = false;
        }
    }
}
