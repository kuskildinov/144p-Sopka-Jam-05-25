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
            case TriggetType.GO_TO_LOCATION_ACTIVE:
                {
                    TryChangeLocation(trigger.Index);
                    break;
                }
            case TriggetType.GO_TO_LOCATION_PASSIVE:
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
            case TriggetType.LEVEL_ACTIVATION:
                {
                    TryActivateLevelTrigger(trigger.Index);                  
                    break;
                }
            case TriggetType.BUSH:
                {
                    TryActivateLevelTrigger(trigger.Index);
                    break;
                }
            case TriggetType.DETECTION:
                {
                    TryActivateLevelTrigger(trigger.Index);
                    break;
                }
            case TriggetType.TAKE_DAMAGE:
                {
                    TryTakeDamage(trigger.Index);
                    break;
                }
            case TriggetType.ATTACK:
                {
                    TryAttack(trigger.Index);
                    break;
                }

            default:
                break;
        }

        if (trigger.NeedDisappear)
            trigger.gameObject.SetActive(false);
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
        _levelRoot.OnItemTaked(index);
        _itemsRoot.OpenDescriptionByIndex(index);
    }

    private void TryActivateLevelTrigger(int index)
    {
        _levelRoot.ActivateTrigger(index);      
    }

    private void TryTakeDamage(int index)
    {
        _playerRoot.OnPlayerTakeDamage();        
    }

    private void TryAttack(int index)
    {
        Debug.Log("Вызывть анимацию атаки у игрока");

        _levelRoot.ActivateTrigger(index);
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
    GO_TO_LOCATION_ACTIVE,
    GO_TO_LOCATION_PASSIVE,
    TAKE_ITEM,
    ACTIVE_DIALOG,
    PASSIVE_DIALOG,
    LEVEL_ACTIVATION,
    DETECTION,
    BUSH,
    TAKE_DAMAGE,
    ATTACK,
}
