using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerMovment _playerMovment;
    [SerializeField] private PlayerVisual _playerVisual;
    [SerializeField] private PlayerInteractions _playerInteractions;

    private PlayerRoot _root;
    private IInput _input;   

    public void Initialize(PlayerRoot playerRoot, IInput input, PlayerSettingsSO settings, MovmentType movmentType)
    {
        _root = playerRoot;
        _input = input;     

        _playerMovment.Initialize(this, settings, input, _rigidbody, movmentType);
        _playerVisual.Initialize(this,_input);
        _playerInteractions.Initialize(this,_input);
    }

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

    public void OnPlayerEnterTrigger(Trigger trigger) => _root.OnPlayerEnterTrigger(trigger);

    public void OnPlayerExitTrigger() => _root.OnPlayerExitTrigger();
}
