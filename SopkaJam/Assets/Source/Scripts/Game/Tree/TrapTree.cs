using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTree : Trigger
{
    private const string TIGER_TRAPPED = "TigerTrapped";

    [SerializeField] private TigerRoot _tigerRoot;
    [SerializeField] private float _trapTime;
    [SerializeField] private Animator _animtor;

    private void OnTigerTrapped()
    {
        StartCoroutine(TigerTrapRoutine());
    }

    private IEnumerator TigerTrapRoutine()
    {
        _tigerRoot.HideTiger();
        _animtor.SetBool(TIGER_TRAPPED,true);
        yield return new WaitForSecondsRealtime(_trapTime);
        _animtor.SetBool(TIGER_TRAPPED, false);
        _tigerRoot.ShowTiger();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<TigerDamageTrigger> (out TigerDamageTrigger damageTrigger))
        {
            MainTiger tiger = damageTrigger.Tiger;

            switch (tiger.CurrentState)
            {
                case MainTigerState.MAIN_ATTACK:
                    {
                        Debug.Log("Основная атака");
                        OnTigerTrapped();
                        break;
                    }
                case MainTigerState.LEFT_ATTACK:
                    {
                        Debug.Log("Атака лапой");
                        break;
                    }
                case MainTigerState.RIGHT_ATTACK:
                    {
                        Debug.Log("Атака лапой");
                        break;
                    }
            }

        }
    }
}
