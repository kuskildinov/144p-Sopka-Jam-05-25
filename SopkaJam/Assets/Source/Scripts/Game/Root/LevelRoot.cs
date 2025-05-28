using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRoot : CompositeRoot
{
    [SerializeField] private Level _level;
    [SerializeField] private Fade _fadeUI;
    public override void Compose()
    {
        if (_level == null)
            return;

        _level.Initialize();
    }

    public void LoadSceneByName(string sceneName)
    {
        if (CheckCanLraveLevel())
            StartCoroutine(LoadSceneRoutine(sceneName));
        else
            Debug.Log("Не все предметы собраны");
    }

    public void OnItemTaked()
    {
        _level.OnItemTaked();
    }

    private bool CheckCanLraveLevel()
    {
        if (_level.CanLeaveLevel)
            return true;
        else
            return false;
    }

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        yield return null;
        _fadeUI.FadeOut();
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneName);
    }
}
