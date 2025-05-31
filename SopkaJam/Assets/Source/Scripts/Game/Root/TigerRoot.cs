using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerRoot : CompositeRoot
{
    [SerializeField] private MainTiger _tiger;
    [SerializeField] private PlayerRoot _playerRoot;

    private Vector3 _tigerLastPosition;
    public override void Compose()
    {
        _tiger.gameObject.SetActive(true);
        _tiger.Initialize(this);
    }

    public void Attack(int index) => _tiger.Attack(index);

    public void ShowTiger()
    {      
        _tiger.Reset();
        _tiger.transform.localPosition = _tigerLastPosition;
    }

    public void HideTiger()
    {
        _tigerLastPosition = _tiger.transform.localPosition;
        _tiger.transform.localPosition = new Vector3(_tiger.transform.localPosition.x, 100f,_tiger.transform.localPosition.z);
        _tiger.MoveToTrap();      
    }

    public Vector3 GetPlayerPosition()
    {
        return _playerRoot.GetPlayerPosition();
    }
}
