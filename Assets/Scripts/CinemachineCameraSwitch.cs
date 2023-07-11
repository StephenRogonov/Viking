using UnityEngine;

//Скрипт переключения камеры на другую для схватки с боссом в конце уровня
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
            //Включаем анимацию, которая плавно переходит на другую камеру
            _anim.Play("BossFightCamera");
            //Включаем коллайдеры ограничивающие передвижение босса по финальной локации
            foreach (Collider2D confiner in _bossFightConfiners)
            {
                confiner.enabled = true; 
            }
            //Включаем скрипт движения босса. При запуске игры босс не двигается пока игрок не придёт к месту схватки
            _boss.GetComponent<SkeletonBossController>().enabled = true;
        }
    }
}
