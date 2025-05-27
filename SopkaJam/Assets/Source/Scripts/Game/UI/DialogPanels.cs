using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPanels : MonoBehaviour
{
    [SerializeField] private List<DialogPanel> _panels;

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

    public void TryOpenPanelByIndex(int index)
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

    public void CloseAllPanels()
    {
        _isDialogOpen = false;
        foreach (DialogPanel panel in _panels)
        {
            panel.Close();
        }
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


}
