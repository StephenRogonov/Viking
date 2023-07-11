using UnityEngine;

//Скрипт включения анимации смерти, если здоровье врага/игрока меньше или равно 0
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
