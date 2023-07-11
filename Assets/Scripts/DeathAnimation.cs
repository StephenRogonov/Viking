using UnityEngine;

//������ ��������� �������� ������, ���� �������� �����/������ ������ ��� ����� 0
public class DeathAnimation : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = gameObject.GetComponent<Animator>();
    }

    public void Death()
    {
        _anim.SetBool("isDead", true);
    }
}
