using UnityEngine;

//������ �������� �������, ����������� �������
public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private Rigidbody2D _rb;

    void Start()
    {
        _rb.velocity = transform.right * _projectileSpeed;
    }
}
