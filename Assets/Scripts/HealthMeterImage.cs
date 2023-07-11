using UnityEngine;
using UnityEngine.UI;

//Скрипт отображения шкалы здоровья при получении урона или восстановлении (пока не реализовано) здоровья
public class HealthMeterImage : MonoBehaviour
{
    [SerializeField] private Image _healthBar;

    public void ChangeImage(float percentage)
    {
        _healthBar.fillAmount = percentage;
    }
}
