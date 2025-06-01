using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTree : MonoBehaviour
{
    private const string TIGER_TRAPPED = "TigerTrapped";
    private const string TAKE_DAMAGE = "TakeDamage";

    [SerializeField] private TigerRoot _tigerRoot;
    [SerializeField] private float _trapTime;
    [SerializeField] private Animator _animtor;
    [SerializeField] private Collider2D _tigerTrigger;
    [SerializeField] private Collider2D _attackTrigger;
    [Header("Visual")]
    [SerializeField] private GameObject _mainVisual;
    [SerializeField] private GameObject _brokenVisual;

    private bool _isTigerTrapped;

    public void BrakeTree()
    {
        HideTrappedTiger();
        _tigerTrigger.enabled = false;
        _mainVisual.gameObject.SetActive(false);
        _brokenVisual.gameObject.SetActive(true);
        _attackTrigger.enabled = false;
    }

    private void StartTigerTrap()
    {
        ShowTrappedTiger();
        StartCoroutine(TigerTrapRoutine());
    }

    private void OnTakeDamage()
    {
        _animtor.SetTrigger(TAKE_DAMAGE);
    }

    private void ShowTrappedTiger()
    {
        _isTigerTrapped = true;
        _tigerRoot.HideTiger();
        _animtor.SetBool(TIGER_TRAPPED, true);
        _attackTrigger.enabled = true;
    }

    public void HideTrappedTiger()
    {
        _isTigerTrapped = false;
        _animtor.SetBool(TIGER_TRAPPED, false);
        _tigerRoot.ShowTiger();
        StopCoroutine(TigerTrapRoutine());
    }  

    private IEnumerator TigerTrapRoutine()
    {       
        yield return new WaitForSecondsRealtime(_trapTime);
        if(_isTigerTrapped)
        {
            HideTrappedTiger();
        }
        else
        {
            yield break;
        }
       
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
                        StartTigerTrap();
                        break;
                    }
                case MainTigerState.LEFT_ATTACK:
                    {
                        Debug.Log("Атака лапой");
                        OnTakeDamage();
                        break;
                    }
                case MainTigerState.RIGHT_ATTACK:
                    {
                        Debug.Log("Атака лапой");
                        OnTakeDamage();
                        break;
                    }
            }

        }
    }
}
