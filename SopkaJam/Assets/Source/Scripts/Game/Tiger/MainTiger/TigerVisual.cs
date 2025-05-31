using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TigerVisual : MonoBehaviour
{
    private const string WALK = "Walk";
    private const string PREPARE = "Prepare";
    private const string LEFT_ATTACK = "LeftAttack";
    private const string RIGHT_ATTACK = "RightAttack";
    private const string MAIN_ATTACK = "MainAttack";
    private const string STAN = "Stan";

    private Animator _animator;
    private MainTiger _tiger;
    public void Initialize(MainTiger tiger)
    {
        _tiger = tiger;
        _animator = GetComponent<Animator>();
        _tiger.StateChanged += OnTigerStateChanged;
    }

    private void OnDisable()
    {
        _tiger.StateChanged -= OnTigerStateChanged;
    }

    private void OnTigerStateChanged()
    {      
        switch (_tiger.CurrentState)
        {
            case MainTigerState.WALK:
                {
                    BackToWalkState();
                    break;
                }
            case MainTigerState.PREPARE:
                {
                    _animator.SetBool(WALK, false);
                    _animator.SetTrigger(PREPARE);
                    break;
                }
            case MainTigerState.LEFT_ATTACK:
                {
                    _animator.SetBool(WALK, false);
                    _animator.SetTrigger(LEFT_ATTACK);
                    break;
                }
            case MainTigerState.RIGHT_ATTACK:
                {
                    _animator.SetBool(WALK, false);
                    _animator.SetTrigger(RIGHT_ATTACK);
                    break;
                }
            case MainTigerState.MAIN_ATTACK:
                {
                    _animator.SetBool(WALK, false);
                    _animator.SetTrigger(MAIN_ATTACK);
                    break;
                }
            case MainTigerState.STAN:
                {
                    _animator.SetBool(WALK, false);
                    _animator.SetBool(STAN, true);                   
                    break;
                }
        }
    }

    public void BackToWalkState()
    {
        StartCoroutine(BackToWalkStateRoutine());      
    }

    private void ResetAnimatorTriggers()
    {
        _animator.ResetTrigger(PREPARE);
        _animator.ResetTrigger(LEFT_ATTACK);
        _animator.ResetTrigger(RIGHT_ATTACK);
        _animator.ResetTrigger(MAIN_ATTACK);
    }

    private IEnumerator BackToWalkStateRoutine()
    {
        _animator.SetBool(STAN, false);
        _animator.SetBool(WALK, true);
        yield return new WaitForSecondsRealtime(1f);
        ResetAnimatorTriggers();
    }
}
