using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogsRoot : CompositeRoot
{
    [SerializeField] private DialogPanels _dialogPanels;
    [SerializeField] private PlayerRoot _playerRoot;

    public event Action<int> DialogEnded;

    private IInput _input;   
    public override void Compose()
    {
        _input = new DesktopInput();
        _dialogPanels.Initialize(this, _input);
    }

    public void TryShowDialogByIndex(int index, bool withMovmentDeactivation)
    {
        _dialogPanels.TryOpenPanelByIndex(index);
        if (withMovmentDeactivation)
        {
            DeactivatePlayerMovment();            
        }           
    }

    public void OnDialogEnded(int index)
    {
        DialogEnded?.Invoke(index);
        ActivatePlayerMovment();
    }

    public void ActivatePlayerMovment()
    {
        _playerRoot.TogglePlayerMovment(true);
        _playerRoot.TogglePlayerDash(true);
    }

    public void DeactivatePlayerMovment()
    {
        _playerRoot.TogglePlayerMovment(false);
        _playerRoot.TogglePlayerDash(false);
    }
}
