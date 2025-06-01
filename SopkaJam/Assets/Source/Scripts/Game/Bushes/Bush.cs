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
    [SerializeField] private Animator _animator;   
    [SerializeField] private float _holdTigerTime = 3f;
    [SerializeField] private float _animationDuration = 1.5f;

    private TigerBushesLevel _level;   
    
   public void SetLevel(TigerBushesLevel level)
    {
        _level = level;       
    }

    #region >>> SHOW HIDE
    public void ShowTiger(bool isLeft)
    {       
        StartCoroutine(ShowTigerRoutine(isLeft));
    } 

    public void OnTigerHide()
    {
        _level.OnTigerHide(this);
    }

    private IEnumerator ShowTigerRoutine(bool isLeft)
    {
        if (isLeft)
        {           
            _animator.SetTrigger(LEFT_ON);
            yield return new WaitForSecondsRealtime(_holdTigerTime);
            _animator.SetTrigger(LEFT_OFF);
            yield return new WaitForSecondsRealtime(_animationDuration);
        }
        else
        {           
            _animator.SetTrigger(RIGHT_ON);
            yield return new WaitForSecondsRealtime(_holdTigerTime);
            _animator.SetTrigger(RIGHT_OFF);
            yield return new WaitForSecondsRealtime(_animationDuration);
        }
        
        yield break;
    }
    #endregion

    #region >>> ATTACK

    public void Attack(bool isLeft)
    {
        SoundsRoot.Instance.PlayTigerAttackSound();
        StartCoroutine(AttackRoutine(isLeft));
    }

    private IEnumerator AttackRoutine(bool isLeft)
    {
        if (isLeft)
        {
            _animator.SetTrigger(LEFT_ATTACK);
        }
        else
        {
            _animator.SetTrigger(RIGHT_ATTACK);

        }      
        yield break;
    }
    #endregion

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
