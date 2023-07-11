using UnityEngine;
using UnityEngine.UI;

//������ ����������� ����� �������� ��� ��������� ����� ��� �������������� (���� �� �����������) ��������
public class HealthMeterImage : MonoBehaviour
{
    [SerializeField] private Image _healthBar;

    public void ChangeImage(float percentage)
    {
        _healthBar.fillAmount = percentage;
    }
}
