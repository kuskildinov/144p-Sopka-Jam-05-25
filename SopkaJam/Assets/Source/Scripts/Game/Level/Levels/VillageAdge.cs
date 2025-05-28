using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class VillageAdge : Level
{
    private const int FirstTigerDialogIndex = 0;
      
    [SerializeField] private PlayableDirector _tigerMeetingPlayableDirector;
    [SerializeField] private PlayableDirector _playerDashPlayableDirector;
    [SerializeField] private FirstMeetingTiger _tiger;
    [SerializeField] private string _nextSceneName;
    [Header("Tiger Settings")]
    [SerializeField] private float _prepareTime;
    [SerializeField] private float _jumpDuration;

    private bool _isSecondAct;
    public override void Initialize(LevelRoot levelRoot, IInput input)
    {
        base.Initialize(levelRoot, input);      
    }

    private void Update()
    {
        if(_isSecondAct)
        {
            if(_input.Dash())
            {
                _playerDashPlayableDirector.Play();
                _tiger.ResumeAnimator();
                _canLeaveLevel = true;
            }
        }
    }

    public override void OnItemTaked(int index)
    {
        _root.TryActivateCommentByIndex(index);
    }

    public override void ActivateTrigger(int index)
    {
        if (index == 0)
        {
            _root.DeactivatePlayerMovment();           
            _tigerMeetingPlayableDirector.Play();
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
        _tigerMeetingPlayableDirector.Stop();
        _root.TryActivateDialogByIndex(FirstTigerDialogIndex);
    }

    public void StartSecondAct()
    {
        StartCoroutine(DodgeTigerRoutine());
    }

    public void LeaveScene()
    {
        _root.LoadSceneByName(_nextSceneName);
    }

    private IEnumerator DodgeTigerRoutine()
    {
        _tiger.SetPrepare();
        yield return new WaitForSecondsRealtime(_prepareTime);
        _tiger.SetJump();
        yield return new WaitForSecondsRealtime(_jumpDuration / 2);
        _tiger.StopAnimator();
        _root.DeactivatePlayerMovment();       
        _root.TogglePlayerAnimation(false);
        _root.ShowHintsByType(HintsType.DASH);
        _isSecondAct = true;
        yield break;
    }
}
