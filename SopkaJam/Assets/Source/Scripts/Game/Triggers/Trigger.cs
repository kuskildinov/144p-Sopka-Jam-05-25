using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private TriggetType _type;

    private TriggersRoot _root;
    public int Index => _index;
    public TriggetType Type => _type;

    public void Initialize(TriggersRoot root)
    {
        _root = root;
    }

    public void Activate()
    {
        _root.TryActivateTrigger(this);
    }
}



