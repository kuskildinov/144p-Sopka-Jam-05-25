using System.Collections;
using UnityEngine;

public class ScreenSaver : MonoBehaviour
{
    private const string CLOSE = "Close";

    [SerializeField] private GameObject _panel;
    [SerializeField] private Animator _animator;
    [Header("ScreeSaver Settings")]   
    [SerializeField] private float _screesaverShowTime;

    private ScreenSaverRoot _root;
    public void Initialize(ScreenSaverRoot root)
    {
        _root = root;
        StartCoroutine(ScreenSaverRoutine());
    }   
    public void Close()
    {
        _animator.SetTrigger(CLOSE);
    }

    private IEnumerator ScreenSaverRoutine()
    {       
        yield return new WaitForSecondsRealtime(_screesaverShowTime);
        Close();
        yield return new WaitForSecondsRealtime(_screesaverShowTime);
        _panel.gameObject.SetActive(false);
        _root.LoadMenuScene();

         yield break;
    }
}
