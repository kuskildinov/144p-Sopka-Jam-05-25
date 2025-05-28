using UnityEngine;
using UnityEngine.Playables;

public class VillageAdge : Level
{
    private const int FirstTigerDialogIndex = 0;
    [SerializeField] private PlayableDirector _palyeableDirector;
    [SerializeField] private FirstMeetingTiger _tiger;
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

    public void OnFirstActOver()
    {
        Debug.Log("Тигр подошел!");
        _palyeableDirector.Stop();
        _root.TryActivateDialogByIndex(FirstTigerDialogIndex);
    }

    public void StartSecondAct()
    {

    }
}
