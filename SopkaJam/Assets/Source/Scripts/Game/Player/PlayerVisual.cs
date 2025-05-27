using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Player _player;
    private IInput _input;
    private float _horizontalInput;
   public void Initialize(Player player, IInput input)
    {
        _player = player;
        _input = input;
    }

    private void Update()
    {
        ReadInput();
        CheckLookDirection();
    }

    private void CheckLookDirection()
    {
        if (_horizontalInput > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (_horizontalInput < 0)
            transform.localScale = new Vector3(-1f,1f,1f);
    }

    private void ReadInput()
    {
        _horizontalInput = _input.HorizontalInput();
    }
}
