using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform[] _layers;
    [SerializeField] private float[] _coeff;

    private int LayersCount;

    private void Start()
    {
        LayersCount = _layers.Length;
    }

    private void Update()
    {
        for (int i = 0; i < LayersCount; i++)
        {
            _layers[i].transform.position = transform.position * _coeff[i];
        }
    }
}
