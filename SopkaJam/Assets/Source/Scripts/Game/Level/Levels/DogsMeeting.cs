using UnityEngine;
using UnityEngine.Playables;

public class DogsMeeting : Level
{
    [SerializeField] private PlayableDirector _fogsMeetingPlayableDirector;
    [SerializeField] private string _moveToNextSceneName;

    public override void ActivateTrigger(int index)
    {
        if(index == 0)
        {
            StartMeetingCutScene();
        }
    }

    public void LoadNextScene()
    {
        _root.LoadSceneByName(_moveToNextSceneName);
    }

    private void StartMeetingCutScene()
    {
        _fogsMeetingPlayableDirector.Play();
    }
}
