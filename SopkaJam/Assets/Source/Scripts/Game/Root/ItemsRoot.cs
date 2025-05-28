using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsRoot : CompositeRoot
{
    [SerializeField] private ItemsPanel _itemsPanel;
    public override void Compose()
    {
        //_itemsPanel.CloseAllDescriptions();
    }

    public void OpenDescriptionByIndex(int index)
    {
        _itemsPanel.OpenDescriptionByIndex(index);
    }

    public void OnItemDescriptionOpened()
    {

    }

    public void OnItemDescriptionClosed()
    {

    }
}
