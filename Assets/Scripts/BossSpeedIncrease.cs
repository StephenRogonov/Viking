using UnityEngine;

//Скрипт для ускорения движения босса в направлении персонажа, когда он (персонаж) находится на земле.
//Скрипт висит на статичном коллайдере в локации схватки с боссом
public class BossSpeedIncrease : MonoBehaviour
{
    [SerializeField] private GameObject _boss;
    [SerializeField] private float _speedIncrease; //Коэффициент увеличения скорости
    private SkeletonBossController _bossController;

    private void Awake()
    {
        _bossController = _boss.GetComponent<SkeletonBossController>();
    }

    //В момент вхождения игрока в коллайдер умножаем параметр скорости босса на заданный коэффициент
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _bossController._speed *= _speedIncrease;
        }
    }

    //Пока игрок находится в коллайдере на земле босс должен всегда "смотреть" на персонажа
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

    //Если игрок покинул коллайдер, скорость босса возвращается к исходному значению
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            _bossController._speed /= _speedIncrease;
        }
    }
}
