using UnityEngine;

public class Level : MonoBehaviour
{
    protected LevelRoot _root;
    protected bool _canLeaveLevel;

    public bool CanLeaveLevel => _canLeaveLevel;

   public virtual void Initialize(LevelRoot levelRoot)
    {
        _root = levelRoot;
    }

    public virtual void OnItemTaked(int index)
    {

    }

    public virtual void ActivateTrigger(int index)
    {

    }

    public virtual void OnDialogEnded(int index)
    {

    }
}
