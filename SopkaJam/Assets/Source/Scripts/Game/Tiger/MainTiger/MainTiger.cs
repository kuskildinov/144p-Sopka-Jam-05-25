using System;
using System.Collections;
using UnityEngine;

public class MainTiger : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private TigerMovment _movment;
    [SerializeField] private TigerVisual _visual;
    [Header("Triggers")]
    [SerializeField] private Collider2D _leftHandTrigger;
    [SerializeField] private Collider2D _rightHandTrigger;
    [SerializeField] private Collider2D _mainAttackTrigger;
    [Header("Movment Settigs")]
    [SerializeField] private float _movmentSpeed;
    [Header("Attack Settings")]
    [SerializeField] private int _handAttackTounBeforeMainAttack;
    [SerializeField] private float _timeBeforeCanAttack;
    [SerializeField] private float _prepareTimeForHandAttack;
    [SerializeField] private float _prepareTimeForMainAttack;

    private TigerRoot _root;
    private MainTigerState _currentState;
    private int _handAttackCount;

    public MainTigerState CurrentState => _currentState;

    public event Action StateChanged;
   
   public void Initialize(TigerRoot tigerRoot)
    {
        _root = tigerRoot;
        _movment.Initialize(this,_movmentSpeed);
        _visual.Initialize(this);
        SetNewState(MainTigerState.WALK);
         _handAttackCount = 0;
    }

    public void SetNewState(MainTigerState newState)
    {
        _currentState = newState;
        StateChanged?.Invoke();
    }

    public Vector3 GetPlayerPosition()
    {
        return _root.GetPlayerPosition();
    }

    public void ToggleMovment(bool value) => _movment.ToggleMovment(value);

    public void Attack(int index)
    {
        StartCoroutine(AttackRoutine(index));
    }

    #region >>> TRIGGERS BEHAVIUOR
    private void CheckHandAttackCount()
    {
        if (_handAttackCount >= _handAttackTounBeforeMainAttack)
        {
            HideHandAttackTriggers();
            ShowMainAttackTrigger();
        }
            
    
    }

    private void ShowHandAttackTriggers()
    {
        _leftHandTrigger.enabled = true;
        _rightHandTrigger.enabled = true;
    }

    private void HideHandAttackTriggers()
    {
        _leftHandTrigger.enabled = false;
        _rightHandTrigger.enabled = false;       
    }

    private void ShowMainAttackTrigger()
    {
        _mainAttackTrigger.enabled = true;
    }

    private void HideMainAttackTrigger()
    {
        _mainAttackTrigger.enabled = false;
    }

    #endregion

    private IEnumerator AttackRoutine(int index)
    {
        _movment.ToggleMovment(false);
        SetNewState(MainTigerState.PREPARE);
       
        switch (index)
        {
            case 1:
                {
                    HideHandAttackTriggers();
                    yield return new WaitForSecondsRealtime(_prepareTimeForHandAttack);
                    SetNewState(MainTigerState.RIGHT_ATTACK);
                    _handAttackCount++;
                    yield return new WaitForSecondsRealtime(_timeBeforeCanAttack);
                    ShowHandAttackTriggers();
                    break;
                }
            case 2:
                {
                    yield return new WaitForSecondsRealtime(_prepareTimeForMainAttack);
                   
                    SetNewState(MainTigerState.MAIN_ATTACK);
                    _handAttackCount = 0;
                    yield return new WaitForSecondsRealtime(_timeBeforeCanAttack);
                    ShowHandAttackTriggers();
                    HideMainAttackTrigger();
                    break;
                }
            case 3:
                {
                    HideHandAttackTriggers();
                    yield return new WaitForSecondsRealtime(_prepareTimeForHandAttack);                   
                    SetNewState(MainTigerState.LEFT_ATTACK);
                    _handAttackCount++;
                    yield return new WaitForSecondsRealtime(_timeBeforeCanAttack);
                    ShowHandAttackTriggers();
                    break;
                } 
        }
        CheckHandAttackCount();
    }

    public void MoveToTrap()
    {
        SetNewState(MainTigerState.WALK);       
        ToggleMovment(false);
    }

    public void Reset()
    {
        SetNewState(MainTigerState.WALK);
        ToggleMovment(true);
        _handAttackCount = 0;
    }
}

public enum MainTigerState
{
    WALK,
    PREPARE,
    LEFT_ATTACK,
    RIGHT_ATTACK,
    MAIN_ATTACK
}
