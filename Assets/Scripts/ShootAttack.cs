using UnityEngine;
using UnityEngine.Events;

//Скрипт дистанционной атаки
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
        //По нажатии кнопки стрельбы (правая кнопка мыши) создаётся снаряд в точке атаки, направленный относительно поворота
        //персонажа
        GameObject projectile = Instantiate(_projectile, _firePoint.position, _firePoint.rotation);
    }

    //По окончании атаки персонаж может продолжать движение по оси X
    public void EndShooting()
    {
        _anim.SetBool("isShooting", false);
        OnRangeAttackEnd.Invoke();
    }
}
