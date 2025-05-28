using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHouseLevel : Level
{
    [SerializeField] private int _itemToTakeCount;

    private int _takedItemCounter;
    public override void Initialize(LevelRoot levelRoot, IInput input)
    {
        base.Initialize(levelRoot, input);
        _takedItemCounter = 0;
    }

    public override void OnItemTaked(int index)
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
