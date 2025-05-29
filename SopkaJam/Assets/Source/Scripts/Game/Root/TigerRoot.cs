using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerRoot : CompositeRoot
{
    [SerializeField] private MainTiger _tiger;
    [SerializeField] private PlayerRoot _playerRoot;
    public override void Compose()
    {
        _tiger.Initialize(this);
    }

    public Vector3 GetPlayerPosition()
    {
        return _playerRoot.GetPlayerPosition();
    }
}
