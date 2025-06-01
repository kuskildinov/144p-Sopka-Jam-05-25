using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerMovment _playerMovment;
    [SerializeField] private PlayerVisual _playerVisual;
    [SerializeField] private PlayerInteractions _playerInteractions;

    private PlayerState _currentState;
    private PlayerRoot _root;
    private IInput _input;

    public PlayerState CurrentState => _currentState;

    public event Action PlayerStateChanged;

    public void Initialize(PlayerRoot playerRoot, IInput input, PlayerSettingsSO settings, MovmentType movmentType)
    {
        _root = playerRoot;
        _input = input;     

        _playerMovment.Initialize(this, settings, input, _rigidbody, movmentType);
        _playerVisual.Initialize(this,_input);
        _playerInteractions.Initialize(this,_input);

        ChangeState(PlayerState.IDLE);
    }

    #region >>> MOVMENT

    public void TogglePlayerMovment(bool value)
    {
        if (value)
        {
            _playerMovment.ActivateMovment();
            _playerVisual.ActivateRotation();
        }
           
        else
        {
            _playerMovment.DeactivateMovment();
            _playerVisual.DeactivateRotation();
        }
          
    }

    public void TogglePlayerDash(bool value)
    {
        if (value)
            _playerMovment.ActivateDash();
        else
            _playerMovment.DeactivateDash();
    }

    public void ToggleRotation(bool value)
    {
        if (value)
            _playerVisual.ActivateRotation();
        else
            _playerVisual.DeactivateRotation();
    }

    #endregion

    #region >>> INTERACTIONS

    public void OnPlayerEnterTrigger(Trigger trigger, bool showHints) => _root.OnPlayerEnterTrigger(trigger, showHints);

    public void OnPlayerExitTrigger() => _root.OnPlayerExitTrigger();

    public void OnItemTaked()
    {
        StartCoroutine(TakeItemRoutine());
    }

    public void OnAttack()
    {
        StartCoroutine(AttackRoutine());
    }

    public void OnTakeDamage()
    {
        StartCoroutine(TakeDamageRoutine());
    }

    #endregion

    #region >>> VISUAL

    public void ChangeState(PlayerState newState)
    {       
        _currentState = newState;
        PlayerStateChanged?.Invoke();
    }

    public void TogglePlayerAnimation(bool value)
    {
        _playerVisual.TogglePlayerAnimation(value);
    }

    #endregion

    private IEnumerator AttackRoutine()
    {
        ChangeState(PlayerState.ATTACK);
        TogglePlayerMovment(false);
        TogglePlayerDash(false);
        yield return new WaitForSecondsRealtime(1f);
        TogglePlayerMovment(true);
        if (_root.CanDash)
            TogglePlayerDash(true);
        ChangeState(PlayerState.IDLE);
    }

    private IEnumerator TakeItemRoutine()
    {
        ChangeState(PlayerState.PICK_UP);
        TogglePlayerMovment(false);
        TogglePlayerDash(false);
        yield return new WaitForSecondsRealtime(1f);
        TogglePlayerMovment(true);
        if(_root.CanDash)
            TogglePlayerDash(true);
        ChangeState(PlayerState.IDLE);
    }

    private IEnumerator TakeDamageRoutine()
    {
        ChangeState(PlayerState.TAKE_DAMAGE);
        TogglePlayerMovment(false);
        TogglePlayerDash(false);
        yield return new WaitForSecondsRealtime(1f);
        TogglePlayerMovment(true);
        if (_root.CanDash)
            TogglePlayerDash(true);
        ChangeState(PlayerState.IDLE);
    }


}

public enum PlayerState
{
    IDLE,
    WALK,
    RUN,
    DASH,
    ATTACK,
    DEAD,
    CRY,
    PICK_UP,
    TAKE_DAMAGE,
}

