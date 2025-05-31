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
    public override void Compose()
    {
        _input = new DesktopInput();
        _player.Initialize(this,_input, _settings, _currentMovmentType);

        if (_movmentOnAwake)
            TogglePlayerMovment(true);
        else
            TogglePlayerMovment(false);

        if (_dashOnAwake)
            TogglePlayerDash(true);
        else
            TogglePlayerDash(false);

        _currentLifeCount = _playerLifeCount;
    }

    public void TogglePlayerMovment(bool value) => _player.TogglePlayerMovment(value);
    public void TogglePlayerDash(bool value) => _player.TogglePlayerDash(value);
    public void TogglePlayerAnimation(bool value) => _player.TogglePlayerAnimation(value);
    

    public void OnPlayerEnterTrigger(Trigger trigger, bool showHints)
    {
        if(showHints)
            _hintsRoot.ShowHintPanelByTrigger(trigger);
    }

    public void OnPlayerExitTrigger()
    {
        _hintsRoot.CloseAllHints();
    }

    public void OnPlayerTakeDamage()
    {
        Debug.Log("Получили Урон!!");
        _currentLifeCount--;
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
        if(_currentLifeCount <= 0)
        {
            _player.ChangeState(PlayerState.DEAD);
            _levelRoot.OpenGameOverPanel();
        }
    }
}
