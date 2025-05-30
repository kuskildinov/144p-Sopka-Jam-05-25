using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossLevel : Level

{
    [SerializeField] private BossObstacleSpawner _obstacleSpawner;

    public override void Initialize(LevelRoot levelRoot, IInput input)
    {
        base.Initialize(levelRoot, input);

    }
}
