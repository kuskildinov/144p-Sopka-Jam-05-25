using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerVisual : MonoBehaviour
{
    [SerializeField] private bool _needRotate = true;
    private const string IDLE = "Idle";
    private const string WALK = "Walk";
    private const string RUN = "Run";
    private const string DASH = "Dash";
    private const string CRY = "Cry";
    private const string PICK_UP = "PickUp";

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
        if(_needRotate)
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
            case PlayerState.CRY:
                {
                    _animator.SetBool(CRY,true);
                    break;
                }
            case PlayerState.PICK_UP:
                {
                    _animator.SetTrigger(PICK_UP);
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
        _animator.SetBool(CRY, false);
    }
    #endregion


    private void ReadInput()
    {
        _horizontalInput = _input.HorizontalInput();
    }
}
