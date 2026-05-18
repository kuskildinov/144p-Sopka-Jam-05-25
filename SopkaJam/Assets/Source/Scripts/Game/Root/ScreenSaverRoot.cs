using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenSaverRoot : CompositeRoot
{
    [SerializeField] private ScreenSaver _screenSaver_1;
    [SerializeField] private ScreenSaver _screenSaver_2;
    [SerializeField] private string _mainMenuSceneName;
    [Header("ScreeSaver Settings")]
    [SerializeField] private float _screesaverShowTime;

    public override void Compose()
    {
        _screenSaver_1.gameObject.SetActive(false);
        _screenSaver_2.gameObject.SetActive(false);
        _screenSaver_1.Initialize(this);
        _screenSaver_2.Initialize(this);

        StartCoroutine(ScreenSaverRoutine());
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(_mainMenuSceneName);
    }

    private IEnumerator ScreenSaverRoutine()
    {
        _screenSaver_1.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_screesaverShowTime);   
        yield return new WaitForSecondsRealtime(1);
        _screenSaver_2.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_screesaverShowTime);
        _screenSaver_2.Close();
        yield return new WaitForSecondsRealtime(_screesaverShowTime);
        LoadMenuScene();

        yield break;
    }
}
