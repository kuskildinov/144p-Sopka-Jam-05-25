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
    [SerializeField] private Collider2D _damageTrigger;
    [Header("Movment Settigs")]
    [SerializeField] private float _movmentSpeed;
    [Header("Attack Settings")]
    [SerializeField] private int _handAttackTounBeforeMainAttack;
    [SerializeField] private float _attackTime;
    [SerializeField] private float _timeBeforeAgainCanAttack;
    [SerializeField] private float _timeBeforeCanAttackAfterTrap;
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

    private void HideDamageTrigger()
    {
        _damageTrigger.enabled = false;
    }

    #endregion

    public void MoveToTrap()
    {
        StartCoroutine(HideTigerRoutine());

    }

    public void BackToWalk()
    {
        SetNewState(MainTigerState.WALK);
        ToggleMovment(true);
    }


    public void Reset()
    {
        StartCoroutine(ResetTigerRoutine());       
    }

    private IEnumerator AttackRoutine(int index)
    {
        _movment.ToggleMovment(false);
        SetNewState(MainTigerState.PREPARE);
       
        switch (index)
        {
            case 1:
                {
                    HideHandAttackTriggers();
                    HideMainAttackTrigger();
                    yield return new WaitForSecondsRealtime(_prepareTimeForHandAttack);
                    SetNewState(MainTigerState.RIGHT_ATTACK);
                    _handAttackCount++;
                    SoundsRoot.Instance.PlayTigerAttackSound();
                    yield return new WaitForSecondsRealtime(_attackTime);
                    BackToWalk();
                    yield return new WaitForSecondsRealtime(_timeBeforeAgainCanAttack);
                    ShowHandAttackTriggers();
                    break;
                }
            case 2:
                {
                    HideMainAttackTrigger();
                    HideHandAttackTriggers();
                    yield return new WaitForSecondsRealtime(_prepareTimeForMainAttack);                   
                    SetNewState(MainTigerState.MAIN_ATTACK);
                    _handAttackCount = 0;
                    SoundsRoot.Instance.PlayTigerAttackSound();
                    yield return new WaitForSecondsRealtime(_attackTime);
                    BackToWalk();
                    yield return new WaitForSecondsRealtime(_timeBeforeAgainCanAttack);
                    ShowHandAttackTriggers();
                    
                    break;
                }
            case 3:
                {
                    HideHandAttackTriggers();
                    HideMainAttackTrigger();
                    yield return new WaitForSecondsRealtime(_prepareTimeForHandAttack);                   
                    SetNewState(MainTigerState.LEFT_ATTACK);
                    _handAttackCount++;
                    SoundsRoot.Instance.PlayTigerAttackSound();
                    yield return new WaitForSecondsRealtime(_attackTime);
                    BackToWalk();
                    yield return new WaitForSecondsRealtime(_timeBeforeAgainCanAttack);
                    ShowHandAttackTriggers();
                    break;
                } 
        }
        CheckHandAttackCount();
    }

    private IEnumerator HideTigerRoutine()
    {
        HideHandAttackTriggers();
        HideMainAttackTrigger();
        HideDamageTrigger();
        SetNewState(MainTigerState.WALK);
        yield return null;      
        ToggleMovment(false);
    }

    private IEnumerator ResetTigerRoutine()
    {
        SetNewState(MainTigerState.STAN);
        yield return new WaitForSecondsRealtime(_timeBeforeCanAttackAfterTrap);
        SetNewState(MainTigerState.WALK);
        BackToWalk();
        ShowHandAttackTriggers();
        HideMainAttackTrigger();
        HideDamageTrigger();
    }

   
}

public enum MainTigerState
{
    WALK,
    PREPARE,
    LEFT_ATTACK,
    RIGHT_ATTACK,
    MAIN_ATTACK,
    STAN,
}
