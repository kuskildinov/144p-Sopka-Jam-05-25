using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerVisual : MonoBehaviour
{
    private const string IDLE = "Idle";
    private const string WALK = "Walk";
    private const string RUN = "Run";
    private const string DASH = "Dash";

    private Player _player;
    private Animator _animator;
    private IInput _input;
    private float _horizontalInput;

    private bool _canRotate = true;
   
   public void Initialize(Player player, IInput input)
    {
        _player = player;
        _input = input;
        _animator = GetComponent<Animator>();
        _player.PlayerStateChanged += OnPlayerStateChanged;
    }

    private void OnDisable()
    {
        _player.PlayerStateChanged -= OnPlayerStateChanged;
    }

    private void Update()
    {
        ReadInput();
        CheckLookDirection();
    }

    #region >>> ROTATION

    public void ActivateRotation()
    {
        _canRotate = true;
    }

    public void DeactivateRotation()
    {
        _canRotate = false;
    }

    private void CheckLookDirection()
    {
        if (_canRotate == false)
            return;

        if (_horizontalInput > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (_horizontalInput < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    #endregion

    #region >>> ANIMATIONS

    public void TogglePlayerAnimation(bool value)
    {
        if (value)
        {
            _animator.speed = 1f;
        }
        else
        {
            _animator.speed = 0f;
        }
    }

    public void OnPlayerStateChanged()
    {
        PlayerState currentstate = _player.CurrentState;
        ChangeAnimationByState(currentstate);
    }

    private void ChangeAnimationByState(PlayerState currentstate)
    {
        switch (currentstate)
        {
            case PlayerState.IDLE:
                {
                    ResetAnimator();
                    break;
                }

            case PlayerState.WALK:
                {
                    _animator.SetBool(IDLE, false);
                    _animator.SetBool(WALK, true);
                    break;
                }
            case PlayerState.RUN:
                {
                    _animator.SetBool(IDLE, false);
                    _animator.SetBool(RUN, true);
                    break;
                }
            case PlayerState.DASH:
                {                  
                    _animator.SetTrigger(DASH);
                    break;
                }
            default:
                break;
        }
    }

    private void ResetAnimator()
    {
        _animator.SetBool(IDLE, true);
        _animator.SetBool(WALK, false);
        _animator.SetBool(RUN, false);
        _animator.SetBool(DASH, false);
    }
    #endregion


    private void ReadInput()
    {
        _horizontalInput = _input.HorizontalInput();
    }
}
