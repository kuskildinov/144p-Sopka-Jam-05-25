using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _backToMenuButton;
    private LevelRoot _root;
    private IInput _input;
    private bool _pauseActive;
   public void Initialize(LevelRoot levelRoot,IInput input)
    {
        _root = levelRoot;
        _input = input;
        _pauseActive = false;
    }

    private void Update()
    {
        if(_input.Pause())
        {           
            if (!_pauseActive)
                ShowPausePanel();
            else
                ClosePausePanel();
        }
    }

    private void ShowPausePanel()
    {
        _backToMenuButton.onClick.AddListener(OnBackToMenuButtonClicked);
        _pauseActive = true;
        _panel.gameObject.SetActive(true);
        _root.PauseGame();
    }

    private void ClosePausePanel()
    {
        _backToMenuButton.onClick.RemoveAllListeners();
        _pauseActive = false;
        _panel.gameObject.SetActive(false);
        _root.ResumeGame();
    }

    private void OnBackToMenuButtonClicked()
    {
        Time.timeScale = 1f;
        _root.BackToMainMenu();
    }

}
