using UnityEngine;

//Скрипт включения анимации открытия сундука и эффектора, разбрасывающего монеты
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

            //Уничтожаем монеты через 2 секунды
            Destroy(_coins, 2f);
        }
    }
}
