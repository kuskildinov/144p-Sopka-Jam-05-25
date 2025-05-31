using UnityEngine;

public class PlayerRoot : CompositeRoot
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerSettingsSO _settings;
    [SerializeField] private MovmentType _currentMovmentType;
    [SerializeField] private HintsRoot _hintsRoot;
    [SerializeField] private bool _movmentOnAwake;
    [SerializeField] private bool _dashOnAwake;
    private IInput _input;
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

    public Vector3 GetPlayerPosition()
    {
        return _player.transform.position;
    }
}
