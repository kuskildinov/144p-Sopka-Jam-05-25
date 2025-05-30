using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerBushesLevel : Level
{
    [SerializeField] private List<Bush> _bushes;
    [SerializeField] private float _timeBetweenTigerShow = 5f;
    
    private int _currentBushIndex;
    private bool _currentTigerIsLeft;


    public override void Initialize(LevelRoot levelRoot, IInput input)
    {
        base.Initialize(levelRoot, input);
        _canLeaveLevel = true;
        _currentBushIndex = 0;
        ChangeBushToSpawnTiger();
    }

    public override void ActivateTrigger(int index)
    {
        if (index == 10)
        {
            Debug.Log("Нас заметили!");
            TryAttack();
        }
        else
        {
            OnBushTriggerEnter(index);
        }     
    }

    public void OnBushTriggerEnter(int newBushIndex)
    {
        StopCoroutine(ShowTigerRoutine());
        _currentBushIndex = newBushIndex;
        if(_currentBushIndex != newBushIndex)
            ChangeBushToSpawnTiger();
    }

    public void TryAttack()
    {
        if(_currentTigerIsLeft)
        {
            NeighbourTigerAttack();
        }
        else
        {
            CurrentTigerAttack();
        }
    }

    private void ShowCurrntTiger()
    {
        ShowTigerByIndex(_currentBushIndex,false);
        _currentTigerIsLeft = false;
    }

    private void ShowNeighbourTiger()
    {
        ShowTigerByIndex(_currentBushIndex + 1, true);
        _currentTigerIsLeft = true;
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

    private void CurrentTigerAttack()
    {
        foreach (Bush bush in _bushes)
        {
            if (bush.Index == _currentBushIndex)
            {
                bush.Attack(false);
            }
        }
    }

    private void NeighbourTigerAttack()
    {
        foreach (Bush bush in _bushes)
        {
            if (bush.Index == (_currentBushIndex + 1))
            {
                bush.Attack(true);
            }
        }
    }

    private void HideAllTigers()
    {
        foreach (Bush bush in _bushes)
        {
            bush.HideTigers();
        }
    }

    private void ChangeBushToSpawnTiger()
    {
        HideAllTigers();
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
    }
}
