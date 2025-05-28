using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class VillageAdge : Level
{
    private const int FirstTigerDialogIndex = 0;
    [SerializeField] private PlayableDirector _palyeableDirector;
    [SerializeField] private FirstMeetingTiger _tiger;
    [Header("Tiger Settings")]
    [SerializeField] private float _prepareTime;
    [SerializeField] private float _jumpDuration;
    public override void Initialize(LevelRoot levelRoot)
    {
        base.Initialize(levelRoot);      
    }

    public override void ActivateTrigger(int index)
    {
        if (index == 0)
        {
            _root.DeactivatePlayerMovment();
            _palyeableDirector.Play();
        }           
    }

    public override void OnDialogEnded(int index)
    {
        base.OnDialogEnded(index);
        if(index == 0)
        {
            StartSecondAct();
        }
    }

    public void OnFirstActOver()
    {
        Debug.Log("Тигр подошел!");
        _palyeableDirector.Stop();
        _root.TryActivateDialogByIndex(FirstTigerDialogIndex);
    }

    public void StartSecondAct()
    {
        StartCoroutine(DodgeTigerRoutine());
    }

    private IEnumerator DodgeTigerRoutine()
    {
        _tiger.SetPrepare();
        yield return new WaitForSecondsRealtime(_prepareTime);
        _tiger.SetJump();
        yield return new WaitForSecondsRealtime(_jumpDuration / 2);
        _tiger.StopAnimator();

       

    }
}
