using UnityEngine;

public class CutScenePage : MonoBehaviour
{
    private const string CLOSE = "Close";
    private const string OPEN = "Open";

    [SerializeField] private Animator _animator;

    public void Open()
    {
        _animator.SetTrigger(OPEN);
    }

    public void Close()
    {
        _animator.SetTrigger(CLOSE);
    }
}
