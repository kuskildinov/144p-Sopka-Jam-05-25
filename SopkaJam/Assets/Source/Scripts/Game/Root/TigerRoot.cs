using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerRoot : CompositeRoot
{
    [SerializeField] private MainTiger _tiger;
    [SerializeField] private PlayerRoot _playerRoot;
    public override void Compose()
    {
        _tiger.gameObject.SetActive(true);
        _tiger.Initialize(this);
    }

    public void Attack(int index) => _tiger.Attack(index);

    public void ShowTiger()
    {
        _tiger.gameObject.SetActive(true);
        _tiger.SetNewState(MainTigerState.WALK);
        _tiger.ToggleMovment(true);
    }

    public void HideTiger()
    {
        _tiger.ToggleMovment(false);
        _tiger.gameObject.SetActive(false);
    }

    public Vector3 GetPlayerPosition()
    {
        return _playerRoot.GetPlayerPosition();
    }
}
