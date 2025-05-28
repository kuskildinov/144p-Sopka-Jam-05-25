using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMeetingTiger : MonoBehaviour
{
    private const string PREPARE = "Prepare";
    private const string JUMP = "Jump";

    [SerializeField] private Animator _animator;

    public void SetPrepare()
    {
        _animator.SetTrigger(PREPARE);
    }

    public void SetJump()
    {
        _animator.SetTrigger(JUMP);
    }

    public void StopAnimator()
    {
        _animator.speed = 0f;
    }

    public void ResumeAnimator()
    {
        _animator.speed = 1f;
    }
}
