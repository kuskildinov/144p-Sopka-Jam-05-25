using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsRoot : CompositeRoot
{
    [SerializeField] private PlayerRoot _playerRoot;
    [SerializeField] private ItemsPanel _itemsPanel;
    public override void Compose()
    {
        _itemsPanel.Initialize(this);     
    }

    public void OpenDescriptionByIndex(int index)
    {
        _itemsPanel.OpenDescriptionByIndex(index);
    }

    public void OnItemDescriptionOpened()
    {
        DeactivatePlayerMovment();
    }

    public void OnItemDescriptionClosed()
    {
        ActivatePlayerMovment();
    }

    public void ActivatePlayerMovment()
    {
        _playerRoot.TogglePlayerMovment(true);
    }

    public void DeactivatePlayerMovment()
    {
        _playerRoot.TogglePlayerMovment(false);
    }
}
