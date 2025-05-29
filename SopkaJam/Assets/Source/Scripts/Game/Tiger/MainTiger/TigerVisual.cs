using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TigerVisual : MonoBehaviour
{
    private const string PREPARE = "Prepare";
    private const string LEFT_ATTACK = "LeftAttack";
    private const string RIGHT_ATTACK = "RightAttack";
    private const string MAIN_ATTACK = "MainAttack";

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
                    ResetAnimatorTriggers();
                    break;
                }
            case MainTigerState.PREPARE:
                {
                    _animator.SetTrigger(PREPARE);
                    break;
                }
            case MainTigerState.LEFT_ATTACK:
                {
                    _animator.SetTrigger(LEFT_ATTACK);
                    break;
                }
            case MainTigerState.RIGHT_ATTACK:
                {
                    _animator.SetTrigger(RIGHT_ATTACK);
                    break;
                }
            case MainTigerState.MAIN_ATTACK:
                {
                    _animator.SetTrigger(MAIN_ATTACK);
                    break;
                }  
        }
    }

    public void BackToWalkState()
    {
        _tiger.SetNewState(MainTigerState.WALK);
        _tiger.ToggleMovment(true);
    }

    private void ResetAnimatorTriggers()
    {
        _animator.ResetTrigger(PREPARE);
        _animator.ResetTrigger(LEFT_ATTACK);
        _animator.ResetTrigger(RIGHT_ATTACK);
        _animator.ResetTrigger(MAIN_ATTACK);
    }
}
