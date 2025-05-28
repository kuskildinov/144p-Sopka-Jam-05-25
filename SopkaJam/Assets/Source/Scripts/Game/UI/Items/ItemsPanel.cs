using System.Collections.Generic;
using UnityEngine;

public class ItemsPanel : MonoBehaviour
{
    [SerializeField] private List<ItemDescriptionPanel> _descriptions;

    private ItemsRoot _root;

    public void Initialize(ItemsRoot itemsRoot)
    {
        _root = itemsRoot;
        InitializeAllPanels();
    }

    public void OpenDescriptionByIndex(int index)
    {
        if (_descriptions == null || _descriptions.Count <= 0)
            return;

        foreach (ItemDescriptionPanel description in _descriptions)
        {
            if (description.Index == index)
            {
                description.Open();
                _root.OnItemDescriptionOpened();
            }
               
            else
                description.Close();
        }
    }

    public void CloseDescription(ItemDescriptionPanel descriptionPanel)
    {
        descriptionPanel.Close();
        _root.OnItemDescriptionClosed();
    }

    private void InitializeAllPanels()
    {
        foreach (ItemDescriptionPanel panel in _descriptions)
        {
            panel.Initialize(this);
        }
    }

    private void CloseAllDescriptions()
    {
        foreach (ItemDescriptionPanel description in _descriptions)
        {
            CloseDescription(description);
        }
    }
}
