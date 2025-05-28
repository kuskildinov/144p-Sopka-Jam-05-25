using System.Collections.Generic;
using UnityEngine;

public class DialogPanel : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private GameObject _panel;
    [SerializeField] private List<GameObject> _pages;

    private DialogPanels _dialogPanels;
    private int _currentPageIndex;
    public int Index => _index;

    public void Initialize(DialogPanels dialogPanels)
    {
        _currentPageIndex = 0;
        _dialogPanels = dialogPanels;
    }

    public void Open()
    {
        _panel.gameObject.SetActive(true);
        OpenPageByIndex(0);      
    }

    public void Close()
    {
        _panel.gameObject.SetActive(false);
        Reset();
    }

    private void OpenPageByIndex(int index)
    {
        _currentPageIndex = 0;
        for (int i = 0; i < _pages.Count; i++)
        {
            if(i == index)
            {
                _pages[i].gameObject.SetActive(true);
                _currentPageIndex = index;
            }           
        }
    }

    private void CLosePageByIndex(int index)
    {
        for (int i = 0; i < _pages.Count; i++)
        {
            _pages[i].gameObject.SetActive(false);
        }
    }

    public void OpenNextPage()
    {
        CLosePageByIndex(_currentPageIndex);
        _currentPageIndex++;
        if (_currentPageIndex < _pages.Count)
        {           
            OpenPageByIndex(_currentPageIndex);
        }
        else
        {
            _dialogPanels.CloseAllPanels();
        }
    }

    private void Reset()
    {
        _currentPageIndex = 0;
        for (int i = 0; i < _pages.Count; i++)
        {
            CLosePageByIndex(i);
        }
    }
}
