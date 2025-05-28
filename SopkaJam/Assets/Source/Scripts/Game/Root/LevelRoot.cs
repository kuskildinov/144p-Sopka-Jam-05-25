using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRoot : CompositeRoot
{
    [SerializeField] private PlayerRoot _playerRoot;
    [SerializeField] private DialogsRoot _dialogsRoot;
    [SerializeField] private HintsRoot _hintsRoot;
    [SerializeField] private Level _level;
    [SerializeField] private Fade _fadeUI;

    private IInput _input;
    
    public override void Compose()
    {
        if (_level == null)
            return;
        _input = new DesktopInput();
        _level.Initialize(this, _input);
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
        _playerRoot.TogglePlayerDash(false);
    }

    public void TryActivateDialogByIndex(int index)
    {
        _dialogsRoot.TryShowDialogByIndex(index,true);
    }

    public void TryActivateCommentByIndex(int index)
    {
        _dialogsRoot.TryShowCommentByIndex(index);
    }

    public void TogglePlayerAnimation(bool value)
    {
        _playerRoot.TogglePlayerAnimation(value);
    }

    public void ShowHintsByType(HintsType type)
    {
        _hintsRoot.ShowHintByType(type);
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
