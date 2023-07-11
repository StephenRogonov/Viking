using UnityEngine;

//������ ��� ��������� ������������ ���������� UI � ������ ������ ������
public class FadeUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup _deathUI;

    private bool _fadeIn = false;

    public void ShowUI()
    {
        _fadeIn = true;
    }

    private void Update()
    {
        if (_fadeIn)
        {
            if (_deathUI.alpha < 1)
            {
                _deathUI.alpha += Time.deltaTime;
            }
            else
            {
                _fadeIn = false;
            }
        }
    }
}
