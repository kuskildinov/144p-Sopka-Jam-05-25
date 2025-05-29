using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTiger : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private TigerMovment _movment;
    [Header("Movment Settigs")]
    [SerializeField] private float _movmentSpeed;
    private TigerRoot _root;
   public void Initialize(TigerRoot tigerRoot)
    {
        _root = tigerRoot;
        _movment.Initialize(this,_movmentSpeed);
    }

    public Vector3 GetPlayerPosition()
    {
        return _root.GetPlayerPosition();
    }
}
