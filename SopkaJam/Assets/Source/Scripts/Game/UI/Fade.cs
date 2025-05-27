using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private const string FadeInTrigger = "FadeIn";
    private const string FadeOutTrigger = "FadeOut";
    [SerializeField] private Animator _animator;
   public void FadeIn()
    {
        _animator.SetTrigger(FadeInTrigger);
    }

    public void FadeOut()
    {
        _animator.SetTrigger(FadeOutTrigger);
    }
}
