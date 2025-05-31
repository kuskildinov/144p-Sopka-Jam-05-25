using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSaverRoot : CompositeRoot
{
    [SerializeField] private ScreenSaver _screenSaver;
    [SerializeField] private string _mainMenuSceneName;
    public override void Compose()
    {
        _screenSaver.gameObject.SetActive(true);
        _screenSaver.Initialize(this);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(_mainMenuSceneName);
    }
}
