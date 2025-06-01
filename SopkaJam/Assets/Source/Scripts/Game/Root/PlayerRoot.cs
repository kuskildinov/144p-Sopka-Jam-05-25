using System.Collections;
using UnityEngine;

public class PlayerRoot : CompositeRoot
{
    [Header("Player Settings")]
    [SerializeField] private Player _player;
    [SerializeField] private PlayerSettingsSO _settings;
    [Header("Movment Settings")]
    [SerializeField] private MovmentType _currentMovmentType;
    [SerializeField] private bool _movmentOnAwake;
    [SerializeField] private bool _dashOnAwake;
    [Header("Player Health Settings")]
    [SerializeField] private int _playerLifeCount = 3;
    [Header("Links")]
    [SerializeField] private LevelRoot _levelRoot;
    [SerializeField] private HintsRoot _hintsRoot;
    [SerializeField] private PlayerUI _playerUI;

    private IInput _input;
    private int _currentLifeCount;
    private bool _playerAlive;
    public bool CanDash => _dashOnAwake;
    public override void Compose()
    {
        _input = new DesktopInput();
        _currentLifeCount = _playerLifeCount;
        _playerAlive = true;
        if (_player == null)
            return;

        _player.Initialize(this,_input, _settings, _currentMovmentType);

        if (_movmentOnAwake)
            TogglePlayerMovment(true);
        else
            TogglePlayerMovment(false);

        if (_dashOnAwake)
            TogglePlayerDash(true);
        else
            TogglePlayerDash(false);

        
       
    }

    public void TogglePlayerMovment(bool value) => _player.TogglePlayerMovment(value);
    public void TogglePlayerDash(bool value) => _player.TogglePlayerDash(value);
    public void TogglePlayerAnimation(bool value) => _player.TogglePlayerAnimation(value);

    public void TogglePlayerCry(bool value)
    {
        if (value)
            _player.ChangeState(PlayerState.CRY);
        else
            _player.ChangeState(PlayerState.IDLE);
    }

    public void OnPlayerEnterTrigger(Trigger trigger, bool showHints)
    {
        if(showHints)
            _hintsRoot.ShowHintPanelByTrigger(trigger);       
    }

    public void OnPlayerExitTrigger()
    {
        _hintsRoot.CloseAllHints();
    }

    public void OnPlayerAttack()
    {
        _player.OnAttack();
    }

    public void OnPlayerTakeItem()
    {
        _player.OnItemTaked();
    }

    public void OnPlayerTakeDamage()
    {
        Debug.Log("Получили Урон!!");
        if(_player != null)
            _player.OnTakeDamage();
        _currentLifeCount--;
        if(_playerUI != null)
            _playerUI.UpdateLifeCount(_currentLifeCount);
        CheckPlayerLifeCount();
    }

    public Vector3 GetPlayerPosition()
    {
        return _player.transform.position;
    }

    public void ResumeGame()
    {
        TogglePlayerMovment(true);
        if (_dashOnAwake)
            TogglePlayerDash(true);
    }

    public void PauseGame()
    {
        TogglePlayerMovment(false);
        TogglePlayerDash(false);

    }

    private void CheckPlayerLifeCount()
    {
        if(_currentLifeCount <= 0 && _playerAlive)
        {
            _playerAlive = false;
            if(_player != null)
            {
                OnPlayerDead();
            }           
            _levelRoot.OpenGameOverPanel();
        }
    }

    private void OnPlayerDead()
    {
        _player.ChangeState(PlayerState.DEAD);
        _player.TogglePlayerMovment(false);
        _player.ToggleRotation(false);

        _levelRoot.OnPlayerDead();
    }

   
}
