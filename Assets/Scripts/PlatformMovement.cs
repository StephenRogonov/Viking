using UnityEngine;
//Скрип не используется в первом уровне
public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float _motorSpeed;
    private SliderJoint2D _sliderJoint;
    private JointLimitState2D _limitsRef;
    private JointMotor2D _motor;

    private void Start()
    {
        _sliderJoint = gameObject.GetComponent<SliderJoint2D>();
        _motor = _sliderJoint.motor;
    }

    private void Update()
    {
        _limitsRef = _sliderJoint.limitState;
        if (_limitsRef == JointLimitState2D.LowerLimit)
        {
            _motor.motorSpeed = _motorSpeed;
            _sliderJoint.motor = _motor;
        }
        else if (_limitsRef == JointLimitState2D.UpperLimit)
        {
            _motor.motorSpeed = _motorSpeed * -1;
            _sliderJoint.motor = _motor;
        }
    }
}
