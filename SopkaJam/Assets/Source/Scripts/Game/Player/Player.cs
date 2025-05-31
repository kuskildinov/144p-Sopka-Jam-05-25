using System;
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

    #endregion

    #region >>> INTERACTIONS

    public void OnPlayerEnterTrigger(Trigger trigger, bool showHints) => _root.OnPlayerEnterTrigger(trigger, showHints);

    public void OnPlayerExitTrigger() => _root.OnPlayerExitTrigger();

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


}

public enum PlayerState
{
    IDLE,
    WALK,
    RUN,
    DASH,
    ATTACK,
    DEAD,
}

