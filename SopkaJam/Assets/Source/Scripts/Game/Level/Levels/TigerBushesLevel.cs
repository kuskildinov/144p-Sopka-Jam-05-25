using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerBushesLevel : Level
{
    [SerializeField] private List<Bush> _bushes;
    
    int _currentBushIndex;

    public override void Initialize(LevelRoot levelRoot, IInput input)
    {
        base.Initialize(levelRoot, input);
        _currentBushIndex = 0;
        ChangeBushToSpawnTiger();
    }

    public override void ActivateTrigger(int index)
    {
        OnBushTriggerEnter(index);
    }

    public void OnBushTriggerEnter(int newBushIndex)
    {
        _currentBushIndex = newBushIndex;
        ChangeBushToSpawnTiger();
    }

    private void ChangeBushToSpawnTiger()
    {
        foreach (Bush bush in _bushes)
        {
            if(bush.Index == _currentBushIndex || (bush.Index + 1) == _currentBushIndex)
            {
                bush.ShowTiger(true);
            }
        }       
    }
}
