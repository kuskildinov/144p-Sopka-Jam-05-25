using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneRoot : CompositeRoot
{
    [SerializeField] private CutScenePanel _cutScenePanel;
    [SerializeField] private Fade _fadeUI;
    [SerializeField] private string _nextSceneName;

    private IInput _input;
    public override void Compose()
    {
        _input = new DesktopInput();
        _cutScenePanel.Initialize(this, _input);
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        yield return null;
        _fadeUI.FadeOut();
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(_nextSceneName);
    }
}
