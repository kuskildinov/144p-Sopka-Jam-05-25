using UnityEngine;

public class PlayerRoot : CompositeRoot
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerSettingsSO _settings;
    [SerializeField] private MovmentType _currentMovmentType;
    private IInput _input;
    public override void Compose()
    {
        _input = new DesktopInput();
        _player.Initialize(this,_input, _settings, _currentMovmentType);
    }
}
