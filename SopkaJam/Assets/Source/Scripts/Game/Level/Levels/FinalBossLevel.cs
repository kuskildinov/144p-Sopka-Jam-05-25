using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossLevel : Level
{
    private const float ObstaclePassTime = 10f;
    private const float BossAttackTime = 2f;
    private const float BossSlapTime = .1f;
    private const float ShowAttentionTime = 1f;

    [SerializeField] private FinalBoss _boss;
    [SerializeField] private BossObstacleSpawner _obstacleSpawner;    
    [Header("Attentions")]
    [SerializeField] private GameObject _topAttantion;
    [SerializeField] private GameObject _middleAttention;
    [SerializeField] private GameObject _bottomAttention;

    public override void Initialize(LevelRoot levelRoot, IInput input)
    {
        base.Initialize(levelRoot, input);
       StartCoroutine(LevelRoutine());
    }

    

    private IEnumerator LevelRoutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        #region ‘¿«¿ 1
        _middleAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(ShowAttentionTime);
        _boss.Attack(BossAttackType.MIDDLE);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        _middleAttention.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(BossAttackTime);
        yield return null;
        #endregion
        #region ‘¿«¿ 2
        _topAttantion.gameObject.SetActive(true);
        _bottomAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(ShowAttentionTime);
        _boss.Attack(BossAttackType.TOP_BOTTOM);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        _topAttantion.gameObject.SetActive(false);
        _bottomAttention.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(BossAttackTime);
        yield return null;
        #endregion

        yield return null;



    }

   
}
