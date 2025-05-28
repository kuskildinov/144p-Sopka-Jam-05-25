using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHouseLevel : Level
{
    [SerializeField] private int _itemToTakeCount;

    private int _takedItemCounter;
    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OnItemTaked()
    {
        _takedItemCounter++;
        CheckAllItemsCollected();
    }

    private void CheckAllItemsCollected()
    {
        if (_takedItemCounter >= _itemToTakeCount)
        {
            _canLeaveLevel = true;
        }
        else
        {
            _canLeaveLevel = false;
        }
    }


}
