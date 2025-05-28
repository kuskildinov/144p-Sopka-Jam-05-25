using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPanels : MonoBehaviour
{
    [SerializeField] private List<DialogPanel> _panels;
    [SerializeField] private float _thinkingPanelTime;

    private DialogsRoot _root;
    private DialogPanel _currentOpenDialogPanel;
    private IInput _input;

    private bool _isDialogOpen;

    public void Initialize(DialogsRoot dialogsRoot, IInput input)
    {
        _root = dialogsRoot;
        _input = input;
        InitializePanels();
    }

    private void Update()
    {       
        if (_isDialogOpen == false)
            return;

        if(_input.Interaction())
        {
            TryOpenNextPage();
        }

    }

    public void TryOpenDialogPanelByIndex(int index)
    {       
        foreach (DialogPanel panel in _panels)
        {
            if (panel.Index == index)
            {              
                panel.Open();
                _currentOpenDialogPanel = panel;
                _isDialogOpen = true;
            }
               
            else
                panel.Close();
        }
    }

    public void TryOpenCommentByIndex(int index)
    {
        StartCoroutine(ThinkingRoutine(index));
    }

    public void CloseCommentByIndex(int index)
    {
        foreach (DialogPanel panel in _panels)
        {
            if (panel.Index == index)
            {
                panel.Close();
                _currentOpenDialogPanel = null;
                _isDialogOpen = false;
            }
        }
    }

    public void CloseAllPanels()
    {
        _isDialogOpen = false;
        foreach (DialogPanel panel in _panels)
        {
            panel.Close();
        }

        _root.OnDialogEnded(_currentOpenDialogPanel.Index);
        _currentOpenDialogPanel = null;
     }

    private void TryOpenNextPage()
    {
        _currentOpenDialogPanel.OpenNextPage();
    }

    private void InitializePanels()
    {
        foreach (DialogPanel panel in _panels)
        {
            panel.Initialize(this);
        }
    }

    private IEnumerator ThinkingRoutine(int index)
    {        
        TryOpenDialogPanelByIndex(index);
        yield return new WaitForSecondsRealtime(_thinkingPanelTime);
        CloseCommentByIndex(index);
    }


}
