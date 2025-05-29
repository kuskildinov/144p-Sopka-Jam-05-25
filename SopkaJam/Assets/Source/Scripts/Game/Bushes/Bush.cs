using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : Trigger
{
    private const string RIGHT_ON = "RightOn";
    private const string RIGHT_OFF = "RightOff";
    private const string LEFT_ON = "LeftOn";
    private const string LEFT_OFF = "LeftOff";
    private const int ShowAnimationDuration = 1;

    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _rightDetectionTrigger;
    [SerializeField] private GameObject _leftDetectionTrigger;

    public void ShowTiger(bool isLeft)
    {
        StartCoroutine(ShowTigerRoutine(isLeft));
    }

    public void HideTigers()
    {
        _animator.SetTrigger(RIGHT_OFF);
        _animator.SetTrigger(LEFT_OFF);
        _rightDetectionTrigger.gameObject.SetActive(false);
        _leftDetectionTrigger.gameObject.SetActive(false);
    }

    private IEnumerator ShowTigerRoutine(bool isLeft)
    {
        if(isLeft)
        {
            _animator.SetTrigger(LEFT_ON);
            yield return new WaitForSecondsRealtime(ShowAnimationDuration / 2);
            _leftDetectionTrigger.gameObject.SetActive(true);
        }
        else
        {
            _animator.SetTrigger(RIGHT_ON);
            yield return new WaitForSecondsRealtime(ShowAnimationDuration / 2);
            _rightDetectionTrigger.gameObject.SetActive(true);
        }

        yield return new WaitForSecondsRealtime(3f);
        HideTigers();
    }
}
