using System;
using System.Collections;
using UnityEngine;

public class MainTiger : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private TigerMovment _movment;
    [SerializeField] private TigerVisual _visual;
    [Header("Movment Settigs")]
    [SerializeField] private float _movmentSpeed;
    [SerializeField] private float _prepareTimeForHandAttack;
    [SerializeField] private float _prepareTimeForMainAttack;

    private TigerRoot _root;
    private MainTigerState _currentState;

    public MainTigerState CurrentState => _currentState;

    public event Action StateChanged;
   
   public void Initialize(TigerRoot tigerRoot)
    {
        _root = tigerRoot;
        _movment.Initialize(this,_movmentSpeed);
        _visual.Initialize(this);
        _currentState = MainTigerState.WALK;
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

    private IEnumerator AttackRoutine(int index)
    {
        _movment.ToggleMovment(false);
        SetNewState(MainTigerState.PREPARE);
       
        switch (index)
        {
            case 1:
                {
                    yield return new WaitForSecondsRealtime(_prepareTimeForHandAttack);
                    SetNewState(MainTigerState.RIGHT_ATTACK);
                    break;
                }
            case 2:
                {
                    yield return new WaitForSecondsRealtime(_prepareTimeForMainAttack);
                    SetNewState(MainTigerState.MAIN_ATTACK);
                    break;
                }
            case 3:
                {
                    yield return new WaitForSecondsRealtime(_prepareTimeForHandAttack);
                    SetNewState(MainTigerState.LEFT_ATTACK);
                    break;
                } 
        }
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
