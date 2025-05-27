using UnityEngine;

public class DesktopInput : IInput
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";
    public float HorizontalInput()
    {
        return Input.GetAxis(HorizontalAxis);
    }
    public float VerticalInput()
    {
        return Input.GetAxis(VerticalAxis);
    }
    public bool Interaction()
    {
        return Input.GetMouseButton(0);
    }

    public bool Dash()
    {
        return Input.GetMouseButton(1);
    }
}
