using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRoot : CompositeRoot
{
    [SerializeField] private PlayerRoot _playerRoot;
    [SerializeField] private DialogsRoot _dialogsRoot;
    [SerializeField] private Level _level;
    [SerializeField] private Fade _fadeUI;
    public override void Compose()
    {
        if (_level == null)
            return;

        _level.Initialize(this);
        _dialogsRoot.DialogEnded += OnDialogEnded;
    }

    private void OnDisable()
    {
        _dialogsRoot.DialogEnded -= OnDialogEnded;
    }

    public void LoadSceneByName(string sceneName)
    {
        if (CheckCanLraveLevel())
            StartCoroutine(LoadSceneRoutine(sceneName));     
    }

    public void OnItemTaked(int index)
    {
        _level.OnItemTaked(index);
    }

    public void OnDialogEnded(int index)
    {
        _level.OnDialogEnded(index);
    }

    public void ActivateTrigger(int index)
    {
        _level.ActivateTrigger(index);
    }

    public void ActivatePlayerMovment()
    {
        _playerRoot.TogglePlayerMovment(true);
    }

    public void DeactivatePlayerMovment()
    {
        _playerRoot.TogglePlayerMovment(false);
    }

    public void TryActivateDialogByIndex(int index)
    {
        _dialogsRoot.TryShowDialogByIndex(index,true);
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
