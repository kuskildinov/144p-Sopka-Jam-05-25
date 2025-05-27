using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerMovment _playerMovment;
    private IInput _input;   

    public void Initialize(IInput input, PlayerSettingsSO settings, MovmentType movmentType)
    {
        _input = input;     

        _playerMovment.Initialize(this, settings, input, _rigidbody, movmentType);
    }
}
