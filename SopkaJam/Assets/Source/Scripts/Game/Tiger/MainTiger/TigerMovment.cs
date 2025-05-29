using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerMovment : MonoBehaviour
{
    private MainTiger _tiger;
    private float _movmentSpeed;

    private bool _canMove;
   public void  Initialize(MainTiger tiger, float movmentSpeed)
    {
        _tiger = tiger;
        _movmentSpeed = movmentSpeed;
        _canMove = true;
    }

    private void Update()
    {
        if (_canMove)
            Movment();
    }

    public void Movment()
    {
        Vector3 playerPosition = _tiger.GetPlayerPosition();
        Vector3 targetPoint = new Vector3(playerPosition.x,_tiger.transform.localPosition.y,_tiger.transform.localPosition.z);

        _tiger.transform.localPosition = Vector3.Lerp(_tiger.transform.localPosition,targetPoint,_movmentSpeed * Time.deltaTime);

    }

    public void ToggleMovment(bool value)
    {
        _canMove = value;
    }
}
