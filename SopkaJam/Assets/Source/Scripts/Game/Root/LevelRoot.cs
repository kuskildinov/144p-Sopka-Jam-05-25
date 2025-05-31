using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRoot : CompositeRoot
{
    [SerializeField] private PlayerRoot _playerRoot;
    [SerializeField] private DialogsRoot _dialogsRoot;
    [SerializeField] private HintsRoot _hintsRoot;
    [SerializeField] private Level _level;
    [SerializeField] private PausePanel _pausePanel;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private Fade _fadeUI;

    private IInput _input;
    private bool _isPaused;

    public bool IsPaused => _isPaused;
    
    public override void Compose()
    {
        if (_level == null)
            return;
        _input = new DesktopInput();
        _level.Initialize(this, _input);
        _pausePanel.Initialize(this,_input);
        if (_gameOverPanel != null)
            _gameOverPanel.Initialize(this);
        _dialogsRoot.DialogEnded += OnDialogEnded;
    }

    private void OnDisable()
    {
        _dialogsRoot.DialogEnded -= OnDialogEnded;
    }

    public void StartGame()
    {
        ActivatePlayerMovment();
        TogglePlayerAnimation(true);
        Time.timeScale = 1f;
        _isPaused = false;
    }

    public void ResumeGame()
    {
        _playerRoot.ResumeGame();
        Time.timeScale = 1f;
        _isPaused = false;
        _level.Resume();
    }

    public void PauseGame()
    {
        _playerRoot.PauseGame();
        Time.timeScale = 0f;
        _isPaused = true;
        _level.Pause();
    }

    public void OnCutSceneStarted()
    {
        DeactivatePlayerMovment();
    }

    public void LoadSceneByName(string sceneName)
    {
        if (CheckCanLeaveLevel())
            StartCoroutine(LoadSceneRoutine(sceneName));     
    }

    public void OnItemTaked(int index)
    {
        _level.OnItemTaked(index);
        _playerRoot.OnPlayerTakeItem();
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

    public void TogglePlayerCry(bool value)
    {
        _playerRoot.TogglePlayerCry(value);
    }

    public void ShowHintsByType(HintsType type)
    {
        _hintsRoot.ShowHintByType(type);
    }

    public void CloseHints()
    {
        _hintsRoot.CloseAllHints();
    }

    public void OpenGameOverPanel()
    {
        if (_gameOverPanel == null)
            return;

        _gameOverPanel.Open();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
   
    private bool CheckCanLeaveLevel()
    {
        if (_level.CheckCanLeaveLevel())
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
