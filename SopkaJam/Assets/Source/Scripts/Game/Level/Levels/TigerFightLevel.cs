using UnityEngine;

public class TigerFightLevel : Level
{
    private const int TreesCount = 3;
    private const int FirstTrapTreeIndex = 4;
    private const int SecondTrapTreeIndex = 5;
    private const int ThirdTrapTreeIndex = 6;

    [SerializeField] private TigerRoot _tigerRoot;
    [SerializeField] private TrapTree _trapTree_1;
    [SerializeField] private TrapTree _trapTree_2;
    [SerializeField] private TrapTree _trapTree_3;
    [SerializeField] private string _nextSceneName;

    private int _brokenTreeCount = 0;

    private void CheeckBrokenTrees()
    {
        if(_brokenTreeCount >= TreesCount)
        {
            _canLeaveLevel = true;
            _root.LoadSceneByName(_nextSceneName);
        }
            
    }

    public override void Initialize(LevelRoot levelRoot, IInput input)
    {
        base.Initialize(levelRoot, input);
      
    }

    public override void ActivateTrigger(int index)
    {
        if(index == FirstTrapTreeIndex)
        {
            _trapTree_1.BrakeTree();
            _brokenTreeCount++;
            CheeckBrokenTrees();
        }
        else if(index == SecondTrapTreeIndex)
        {
            _trapTree_2.BrakeTree();
            _brokenTreeCount++;
            CheeckBrokenTrees();
        }
        else if (index == ThirdTrapTreeIndex)
        {
            _trapTree_3.BrakeTree();
            _brokenTreeCount++;
            CheeckBrokenTrees();
        }
        else
        {
            _tigerRoot.Attack(index);
        }      
    }
}
