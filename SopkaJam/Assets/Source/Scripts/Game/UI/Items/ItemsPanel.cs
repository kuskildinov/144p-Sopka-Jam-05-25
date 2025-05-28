using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsPanel : MonoBehaviour
{
    [SerializeField] private List<ItemDescriptionPanel> _descriptions;

    private ItemsRoot _root;

    public void Initialize(ItemsRoot itemsRoot)
    {
        _root = itemsRoot;
    }

    public void OpenDescriptionByIndex(int index)
    {

    }

    private void CloseDescription(ItemDescriptionPanel descriptionPanel)
    {
        descriptionPanel.gameObject.SetActive(false);
    }

    public void CloseAllDescriptions()
    {
        foreach (ItemDescriptionPanel description in _descriptions)
        {
            CloseDescription(description);
        }
    }
}
