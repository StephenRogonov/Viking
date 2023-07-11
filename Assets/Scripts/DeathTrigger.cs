using UnityEngine;

//Скрипт включения анимации смерти если игрок попадает в смертельную ловушку, либо падает в пропасть с платформы
public class DeathTrigger : MonoBehaviour
{
    private Animator _anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _anim = collision.GetComponentInParent<Animator>();
            _anim.SetBool("isDead", true);
        }
    }
}
