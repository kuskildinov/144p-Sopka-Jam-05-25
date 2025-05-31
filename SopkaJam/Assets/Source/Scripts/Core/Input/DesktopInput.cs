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
        return (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E));
    }

    public bool Dash()
    {
        return Input.GetMouseButtonDown(1);
    }

    public bool AnyKeyDown()
    {
        return Input.anyKey;
    }
}
