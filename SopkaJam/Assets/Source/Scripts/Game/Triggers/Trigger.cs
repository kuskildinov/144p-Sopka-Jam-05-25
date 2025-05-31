using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private TriggetType _type;
    [SerializeField] private bool _needDisappeare;
    public bool NeedDisappear => _needDisappeare;

    private TriggersRoot _root;
    public int Index => _index;
    public TriggetType Type => _type;

    public virtual void Initialize(TriggersRoot root)
    {
        _root = root;
    }

    public virtual void Activate()
    {
        _root.TryActivateTrigger(this);
    }
}



