using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogsRoot : CompositeRoot
{
    [SerializeField] private DialogPanels _dialogPanels;

    private IInput _input;   
    public override void Compose()
    {
        _input = new DesktopInput();
        _dialogPanels.Initialize(this, _input);
    }

    public void TryShowDialogByIndex(int index)
    {
        _dialogPanels.TryOpenPanelByIndex(index);
    }
}
