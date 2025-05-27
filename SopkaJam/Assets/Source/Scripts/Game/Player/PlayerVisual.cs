using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private Player _player;
    private IInput _input;
    private float _horizontalInput;

    private bool _canRotate = true;
   
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
            transform.localScale = new Vector3(-1f,1f,1f);
    }

    private void ReadInput()
    {
        _horizontalInput = _input.HorizontalInput();
    }
}
