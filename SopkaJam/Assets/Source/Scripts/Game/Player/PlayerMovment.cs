using System.Collections;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Player _player;
    private Rigidbody2D _rigidbody;

    private float _speed;
    private float _dashForce = 50f;   
    private float _cooldown = 1f;
    private float _dashTime;
    private float _slowMotionFactor = 0.2f;

    private IInput _input;
    private Vector2 _direction;
    private MovmentType _movmentType;

    private float _horizontalInput;
    private float _verticalInput;

    private bool _canMove = true;
    private bool _canDash = true;

    public void Initialize(Player player, PlayerSettingsSO settings, IInput input, Rigidbody2D rigidbody, MovmentType movmentType)
    {
        _player = player;
        _speed = settings.MovmentSpeed;
        _dashForce = settings.DashForce;
        _cooldown = settings.DashCooldown;
        _dashTime = settings.DashTime;
        _slowMotionFactor = settings.SlowMotionFactor;
        _input = input;
        _rigidbody = rigidbody;
        _movmentType = movmentType;
    }

    private void Update()
    {
        ReadInput();
        if(_canMove)
        {
            SetDirection();
            Move();           
        }
        if (_input.Dash() && _canDash)
            StartDash();
    }

    #region >>> MOVMENT
    private void Move()
    {
        float moveX = _horizontalInput * _speed;
        float moveY = _verticalInput * _speed;

        _rigidbody.velocity = new Vector2(moveX, moveY);
    }

    #endregion

    #region >>> DASH

    private void StartDash()
    {
        StartCoroutine(DashRoutine());
    }

    private IEnumerator DashRoutine()
    {
        _canMove = false;
        _canDash = false;
      
        //// Ёффект замедлени€ времени
        //Time.timeScale = _slowMotionFactor;
        //Time.fixedDeltaTime = 0.02f * Time.timeScale;

        _rigidbody.AddForce(_direction * _dashForce, ForceMode2D.Impulse);

        //// ¬озвращаем нормальное врем€
        //Time.timeScale = 1f;
        //Time.fixedDeltaTime = 0.02f;

        yield return new WaitForSecondsRealtime(_dashTime);
        _rigidbody.velocity = Vector2.zero;
        _canMove = true;
        yield return new WaitForSeconds(_cooldown);
        _canDash = true;

       
    }
    #endregion

    private void SetDirection()
    {
        if(_horizontalInput != 0 || _verticalInput != 0)
            _direction = new Vector2(_horizontalInput,_verticalInput).normalized;
    }

    private void ReadInput()
    {
        if(_canMove)
        {
            _horizontalInput = _input.HorizontalInput();
            if (_movmentType == MovmentType.COMMON)
                _verticalInput = _input.VerticalInput();
            else
                _verticalInput = 0f;
        }
       
    }
}

public enum MovmentType
{
    COMMON,
    HORIZONTAL,
}

