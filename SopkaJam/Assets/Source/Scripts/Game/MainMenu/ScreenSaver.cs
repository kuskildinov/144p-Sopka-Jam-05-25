using System.Collections;
using UnityEngine;

public class ScreenSaver : MonoBehaviour
{
    private const string CLOSE = "Close";

    [SerializeField] private GameObject _panel;
    [SerializeField] private Animator _animator;   

    private ScreenSaverRoot _root;
    public void Initialize(ScreenSaverRoot root)
    {
        _root = root;      
    }   

    public void Close()
    {
        _animator.SetTrigger(CLOSE);
    }    
}
