using System.Collections.Generic;
using UnityEngine;

public class TriggersRoot : CompositeRoot
{
    [SerializeField] private PlayerRoot _playerRoot;
    [SerializeField] private LevelRoot _levelRoot;
    [SerializeField] private DialogsRoot _dialogsRoot;
    [SerializeField] private ItemsRoot _itemsRoot;
    [SerializeField] private TriggersDataSO _triggersData;
    [SerializeField] private List<Trigger> _triggers;

    public override void Compose()
    {
        InitializeTriggers();
    }

    public void TryActivateTrigger(Trigger trigger)
    {
        switch (trigger.Type)
        {
            case TriggetType.GO_TO_LOCATION:
                {
                    TryChangeLocation(trigger.Index);
                    break;
                }
            case TriggetType.TAKE_ITEM:
                {
                    TryTakeItem(trigger.Index);
                    break;
                }
              
            case TriggetType.ACTIVE_DIALOG:
                {
                    TryOpenActiveDialog(trigger.Index);
                    break;
                }
              
            case TriggetType.PASSIVE_DIALOG:
                {
                    TryOpenPassiveDialog(trigger.Index);
                    break;
                }
               
            default:
                break;
        }
    }
  
    private void TryChangeLocation(int index)
    {
        string sceneName = _triggersData.GetLoactionNameByIndex(index);
        if (sceneName == string.Empty)
            return;

        _levelRoot.LoadSceneByName(sceneName);
    }

    private void TryOpenActiveDialog(int index)
    {
        _dialogsRoot.TryShowDialogByIndex(index,true);
    }

    private void TryOpenPassiveDialog(int index)
    {
        _dialogsRoot.TryShowDialogByIndex(index,true);
    }

    private void TryTakeItem(int index)
    {
        _levelRoot.OnItemTaked();
        _itemsRoot.OpenDescriptionByIndex(index);
    }

    private void InitializeTriggers()
    {
        foreach (Trigger trigger in _triggers)
        {
            trigger.Initialize(this);
        }
    }
}

public enum TriggetType
{
    GO_TO_LOCATION,
    TAKE_ITEM,
    ACTIVE_DIALOG,
    PASSIVE_DIALOG,
}
