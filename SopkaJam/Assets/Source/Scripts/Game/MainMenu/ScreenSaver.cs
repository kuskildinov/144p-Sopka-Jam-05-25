using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSaver : MonoBehaviour
{
    private const string CLOSE = "Close";
    [SerializeField] private Animator _animator;

    public void Show()
    {

    }

    public void Close()
    {
        _animator.SetTrigger(CLOSE);
    }
}
