using UnityEngine;

public class Level : MonoBehaviour
{
    protected LevelRoot _root;
    protected bool _canLeaveLevel;
    protected IInput _input;

    public bool CanLeaveLevel => _canLeaveLevel;

   public virtual void Initialize(LevelRoot levelRoot,IInput input)
    {
        _root = levelRoot;
        _input = input;
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

    public virtual bool CheckCanLeaveLevel()
    {
        return false;
    }
}
