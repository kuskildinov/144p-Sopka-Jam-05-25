using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    private const string OPEN = "Open";
    [SerializeField] private GameObject _panel;
    [SerializeField] private Animator _animator;
    [Header("Buttons")]
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _backToMenuButton;

    private LevelRoot _root;
    public void Initialize(LevelRoot levelRoot)
    {
        _root = levelRoot;
    }
    public void Open()
    {
        _animator.SetBool(OPEN,true);
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
        _backToMenuButton.onClick.AddListener(OnBackToMenuButtonClicked);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveAllListeners();
        _backToMenuButton.onClick.RemoveAllListeners();
    }

    private void OnRestartButtonClicked()
    {
        _root.RestartLevel();
    }

    private void OnBackToMenuButtonClicked()
    {
        _root.BackToMainMenu();
    }
}
