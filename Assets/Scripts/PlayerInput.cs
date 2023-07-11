using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Attack))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Attack _attack;
    private ShootAttack _rangeAttack;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _attack = GetComponent<Attack>();
        _rangeAttack = GetComponent<ShootAttack>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxisRaw(GlobalStringVars.HorizontalAxis);
        float verticalDirection = Input.GetAxisRaw(GlobalStringVars.VerticalAxis);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.Jump);

        if (Input.GetButtonDown(GlobalStringVars.MeleeAttack))
        {
            //��������� ����������� �������� ������, ���� �� �� �������� �����
            _playerMovement._canMove = false;
            _attack.StartAttack();
        }

        if (Input.GetButtonDown(GlobalStringVars.RangeAttack))
        {
            _playerMovement._canMove = false;
            _rangeAttack.StartShooting();
        }

        _playerMovement.HorizontalMove(horizontalDirection, isJumpButtonPressed);
        _playerMovement.LadderMovement(verticalDirection);
    }
}
