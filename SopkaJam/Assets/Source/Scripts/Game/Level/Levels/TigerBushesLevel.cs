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
        //Передаем TigerSpawner два куста текущий и больше на 1
    }
}
