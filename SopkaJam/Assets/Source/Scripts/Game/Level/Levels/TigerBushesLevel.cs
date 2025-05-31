using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerBushesLevel : Level
{
    [SerializeField] private List<Bush> _bushes;
      
    private Bush _currentBush;
    private Bush _neighbourBush;
    private int _currentBushIndex;
    private bool _lastWasCurrentBush;
    private bool _isPause;
    private bool _canSpawn;

   
    public override void Initialize(LevelRoot levelRoot, IInput input)
    {
        base.Initialize(levelRoot, input);
        InitializeBushes();
        _currentBushIndex = 0;
        OnCurrentBushChanged();
        ShowCurrentBashTiger();
    }

    private void Update()
    {
        if (_isPause)
        {
            _canSpawn = false;
            return;
        }
        else
        {
            _canSpawn = true;
        }
           
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
        if (newBushIndex < 0 || newBushIndex > _bushes.Count - 1)
        {
            Debug.LogError("ошибка в индексе куста");
            return;
        }
               
        _currentBushIndex = newBushIndex;
        OnCurrentBushChanged();
    }

    private void InitializeBushes()
    {
        foreach (Bush bush in _bushes)
        {
            bush.SetLevel(this);
        }
    }

    private void OnCurrentBushChanged()
    {
        _currentBush = _bushes[_currentBushIndex];
        _neighbourBush = _bushes[_currentBushIndex + 1];
    }

    public override void Pause()
    {
        _isPause = true;
    }

    public override void Resume()
    {
        _isPause = false;       
    }

    #region >>> SHOW HIDE TIGER
    public void OnTigerHide(Bush bush)
    {
        if (_canSpawn == false)
            return;

        if (_lastWasCurrentBush)
        {
            ShowNeighbourBashTiger();
        }
        else
        {
            ShowCurrentBashTiger();
        }
    }

    private void ShowCurrentBashTiger()
    {
        _currentBush.ShowTiger(false);
        _lastWasCurrentBush = true;
    }

    private void ShowNeighbourBashTiger()
    {
        _neighbourBush.ShowTiger(true);
        _lastWasCurrentBush = false;
    }

    #endregion

    #region >>> ATTACK

    public void TryAttack()
    {
        if (!_lastWasCurrentBush)
        {
            NeighbourTigerAttack();
        }
        else
        {
            CurrentTigerAttack();
        }
    }

    private void CurrentTigerAttack()
    {
        _currentBush.Attack(false);
    }

    private void NeighbourTigerAttack()
    {
        _neighbourBush.Attack(true);
    }

    #endregion



















}
