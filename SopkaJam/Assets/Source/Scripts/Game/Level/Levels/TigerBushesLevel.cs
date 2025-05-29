using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerBushesLevel : Level
{
    [SerializeField] private List<Bush> _bushes;
    [SerializeField] private float _timeBetweenTigerShow = 5f;
    
    int _currentBushIndex;

    public override void Initialize(LevelRoot levelRoot, IInput input)
    {
        base.Initialize(levelRoot, input);
        _currentBushIndex = 0;
        ChangeBushToSpawnTiger();
    }

    public override void ActivateTrigger(int index)
    {
        if (index == 10)
        {
            Debug.Log("Нас заметили!");
        }

        OnBushTriggerEnter(index);
        
    }

    public void OnBushTriggerEnter(int newBushIndex)
    {
        StopCoroutine(ShowTigerRoutine());
        _currentBushIndex = newBushIndex;
        if(_currentBushIndex != newBushIndex)
            ChangeBushToSpawnTiger();
    }

    private void ShowCurrntTiger()
    {
        ShowTigerByIndex(_currentBushIndex,false);
    }

    private void ShowNeighbourTiger()
    {
        ShowTigerByIndex(_currentBushIndex + 1, true);
    }

    private void ShowTigerByIndex(int index, bool isLeft)
    {
        foreach (Bush bush in _bushes)
        {
            if (bush.Index == index)
            {
                bush.ShowTiger(isLeft);
            }
        }
    }

    private void ChangeBushToSpawnTiger()
    {
       
        StartCoroutine(ShowTigerRoutine());
    }

    private IEnumerator ShowTigerRoutine()
    {
        while(true)
        {
            ShowCurrntTiger();
            yield return new WaitForSecondsRealtime(_timeBetweenTigerShow);
            ShowNeighbourTiger();
            yield return new WaitForSecondsRealtime(_timeBetweenTigerShow);
        }
       
        yield return null;
    }
}
