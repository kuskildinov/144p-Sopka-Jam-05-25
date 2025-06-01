using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuPanel : MonoBehaviour
{
    private const int FIRST_SCENE_INDEX = 2;
    private const int CHAPTER_ONE_INDEX = 3;
    private const int CHAPTER_TWO_INDEX = 8;
    private const int CHAPTER_TREE_INDEX = 12;
        
    
    [Header("Panels")]
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _selectChapterPanel;
    [SerializeField] private GameObject _confirmExitPanel;
    [SerializeField] private GameObject _startGameFade;
    [Header("Buttons")]
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _selectPageButton;
    [SerializeField] private Button _exitgameButton;
    [SerializeField] private Button _chapter_1_Button;
    [SerializeField] private Button _chapter_2_Button;
    [SerializeField] private Button _chapter_3_Button; 
   public void Initialize()
    {       
#if UNITY_STANDALONE
        _exitgameButton.gameObject.SetActive(true);
#else
        _exitgameButton.gameObject.SetActive(false);
#endif
    }

    private void OnEnable()
    {
        _startGameButton.onClick.AddListener(OnStartGameButtonCliked);
        _selectPageButton.onClick.AddListener(OpenSelectChapterPanel);
        _exitgameButton.onClick.AddListener(OnExitButtonClicked);

        _chapter_1_Button.onClick.AddListener(() =>
        {
            OpenChapterByIndex(CHAPTER_ONE_INDEX);
        });
        _chapter_2_Button.onClick.AddListener(() =>
        {
            OpenChapterByIndex(CHAPTER_TWO_INDEX);
        });
        _chapter_3_Button.onClick.AddListener(() =>
        {
            OpenChapterByIndex(CHAPTER_TREE_INDEX);
        });
    }

    private void OnDisable()
    {
        _selectPageButton.onClick.RemoveAllListeners();
        _selectPageButton.onClick.RemoveAllListeners();
        _exitgameButton.onClick.RemoveAllListeners();

        _chapter_1_Button.onClick.RemoveAllListeners();
        _chapter_2_Button.onClick.RemoveAllListeners();
        _chapter_3_Button.onClick.RemoveAllListeners();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void OpenChapterByIndex(int index)
    {
        StartCoroutine(StartGameFadeRoutin(index));
    }
   
    private void OnStartGameButtonCliked()
    {
        StartCoroutine(StartGameFadeRoutin(FIRST_SCENE_INDEX));
    }

    private void OnExitButtonClicked()
    {
        _confirmExitPanel.gameObject.SetActive(true);
    }

    #region >>> SELECT CHAPTER
    private void OpenSelectChapterPanel()
    {
        _selectChapterPanel.gameObject.SetActive(true);
    }

    private void CloseSelectChapterPanel()
    {
        _selectChapterPanel.gameObject.SetActive(false);
    }

    #endregion
        

    private IEnumerator StartGameFadeRoutin(int sceneIndex)
    {
        _startGameFade.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(sceneIndex);
    }
}
