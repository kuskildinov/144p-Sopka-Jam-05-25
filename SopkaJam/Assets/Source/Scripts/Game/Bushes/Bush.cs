using System.Collections;
using UnityEngine;

public class Bush : Trigger
{
    private const string RIGHT_ON = "RightOn";
    private const string RIGHT_OFF = "RightOff";
    private const string LEFT_ON = "LeftOn";
    private const string LEFT_OFF = "LeftOff";
    private const string LEFT_ATTACK = "LeftAttack";
    private const string RIGHT_ATTACK = "RightAttack";

    private const int ShowAnimationDuration = 1;

    [SerializeField] private Animator _animator;  
    [SerializeField] private float _holdTigerTime = 3f;   

    public void ShowTiger(bool isLeft)
    {
        StartCoroutine(ShowTigerRoutine(isLeft));
    }

    public void HideTigers()
    {
        _animator.SetTrigger(RIGHT_OFF);
        _animator.SetTrigger(LEFT_OFF);
        StartCoroutine(ResetAniamtorRoutine());
    }

    public void Attack(bool isLeft)
    {
        if(isLeft)
        {
            _animator.SetTrigger(LEFT_ATTACK);
          
        }
        else
        {
            _animator.SetTrigger(RIGHT_ATTACK);
          
        }
    }

    private IEnumerator ShowTigerRoutine(bool isLeft)
    {
        if(isLeft)
        {
            _animator.SetTrigger(LEFT_ON);
            Physics.SyncTransforms();
        }
        else
        {
            _animator.SetTrigger(RIGHT_ON);
            Physics.SyncTransforms();
        }

        yield return new WaitForSecondsRealtime(_holdTigerTime);
        HideTigers();
    }

    private IEnumerator ResetAniamtorRoutine()
    {
        yield return new WaitForSecondsRealtime(1f);
        _animator.ResetTrigger(RIGHT_OFF);
        _animator.ResetTrigger(LEFT_OFF);
        _animator.ResetTrigger(LEFT_ATTACK);
        _animator.ResetTrigger(RIGHT_ATTACK);
        yield break;
    }
}
