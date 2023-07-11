using UnityEngine;

//������ ��������� �������� �������� ������� � ���������, ��������������� ������
public class ChestOpening : MonoBehaviour
{
    [SerializeField] private float _burstForce;
    [SerializeField] private GameObject _coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<PointEffector2D>().forceMagnitude = _burstForce;

            //���������� ������ ����� 2 �������
            Destroy(_coins, 2f);
        }
    }
}
