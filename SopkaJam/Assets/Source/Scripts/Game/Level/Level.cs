using UnityEngine;

public class Level : MonoBehaviour
{
    protected bool _canLeaveLevel;

    public bool CanLeaveLevel => _canLeaveLevel;

   public virtual void Initialize()
    {
       
    }

    public virtual void OnItemTaked()
    {

    }
}
