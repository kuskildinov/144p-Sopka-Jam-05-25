using UnityEngine;

public class CutScenePage : MonoBehaviour
{
    private const string CLOSE = "Close";
    [SerializeField] private Animator _animator;

    public void Close()
    {
        _animator.SetTrigger(CLOSE);
    }
}
