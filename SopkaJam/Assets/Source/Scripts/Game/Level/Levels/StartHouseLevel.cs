using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHouseLevel : Level
{   
    [SerializeField] private int _itemToTakeCount;
    [SerializeField] private GameObject _spear;
   
    private int _takedItemCounter;
    private int _lastMotherComment = 6;
    public override void Initialize(LevelRoot levelRoot, IInput input)
    {
        base.Initialize(levelRoot, input);
        _takedItemCounter = 0;
    }

    public override void OnItemTaked(int index)
    {
        if(index == 2)
        {
            ShowSpearOnPlayer();
        }
        _takedItemCounter++;
        CheckAllItemsCollected();
    }

    public override void ActivateTrigger(int index)
    {
        if(index == 0)
        {
            if (_lastMotherComment >= 6)
                _lastMotherComment = 2;
            if (_lastMotherComment < 5)
                _lastMotherComment++;
            else
                _lastMotherComment = 3;
            _root.TryActivateCommentByIndex(_lastMotherComment);
        }
    }

    public override bool CheckCanLeaveLevel()
    {
        if (_canLeaveLevel)
        {
            return true;
        }
           
        else
        {
            _root.TryActivateCommentByIndex(6);
            return false;
        }
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

    private void ShowSpearOnPlayer()
    {
        _spear.gameObject.SetActive(true);
    }


}
