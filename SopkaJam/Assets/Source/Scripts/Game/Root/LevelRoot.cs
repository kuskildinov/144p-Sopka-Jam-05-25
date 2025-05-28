using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRoot : CompositeRoot
{
    [SerializeField] private Level _level;
    [SerializeField] private Fade _fadeUI;
    public override void Compose()
    {
        _level.Initialize();
    }

    public void LoadSceneByName(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    public void OnItemTaked()
    {
        _level.OnItemTaked();
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        yield return null;
        _fadeUI.FadeOut();
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneName);
    }
}
