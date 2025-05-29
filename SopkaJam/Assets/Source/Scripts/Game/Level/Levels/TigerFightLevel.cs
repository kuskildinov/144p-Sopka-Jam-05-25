using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerFightLevel : Level
{
    [SerializeField] private TigerRoot _tigerRoot;
    private const int RightHandTriggerIndex = 1;
    private const int MainAttackTriggerIndex = 2;
    private const int LeftHandTriggerIndex = 3;
    public override void Initialize(LevelRoot levelRoot, IInput input)
    {
        base.Initialize(levelRoot, input);
      
    }

    public override void ActivateTrigger(int index)
    {
        _tigerRoot.Attack(index);
    }
}
