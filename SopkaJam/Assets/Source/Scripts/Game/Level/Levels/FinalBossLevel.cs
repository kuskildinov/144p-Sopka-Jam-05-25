using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossLevel : Level
{
    private const float ObstaclePassTime = 10f;
    private const float BossAttackTime = 2f;
    private const float BossSlapTime = .1f;

    [SerializeField] private FinalBoss _boss;
    [SerializeField] private BossObstacleSpawner _obstacleSpawner;    
    [SerializeField] private const float _pauseTime = 1f;
    [SerializeField] private CameraShake _camera;
    [SerializeField] private ParallaxBackground _paralax;
    [SerializeField] private string _nextSceneName;
    [Header("Attentions")]
    [SerializeField] private GameObject _topAttantion;
    [SerializeField] private GameObject _middleAttention;
    [SerializeField] private GameObject _bottomAttention;

    private bool _playerIsAlive;
    public override void Initialize(LevelRoot levelRoot, IInput input)
    {
        base.Initialize(levelRoot, input);
        _playerIsAlive = true;
       StartCoroutine(LevelRoutine());
    }

    public override void OnPlayerDead()
    {
        _playerIsAlive = false;
        _paralax.StopMovment();
    }

    private void CheckCanChangeScene()
    {
        if(_playerIsAlive)
            _root.LoadSceneByName(_nextSceneName);
    }

    private IEnumerator LevelRoutine()
    {
        yield return new WaitForSecondsRealtime(2f);
        #region ÔÀÇÀ 1
        _middleAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _boss.Attack(BossAttackType.MIDDLE);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _middleAttention.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(BossAttackTime);
        yield return null;
        #endregion
        #region ÔÀÇÀ 2
        _topAttantion.gameObject.SetActive(true);
        _bottomAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _boss.Attack(BossAttackType.TOP);
        _boss.Attack(BossAttackType.BOTTOM);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _topAttantion.gameObject.SetActive(false);
        _bottomAttention.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(BossAttackTime);
        yield return null;
        #endregion
        #region ÔÀÇÀ 3
        _obstacleSpawner.SpawnObstacle(ObstacleType.ROCK, 2);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _topAttantion.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _boss.Attack(BossAttackType.TOP);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _topAttantion.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(BossAttackTime);
        yield return null;
        #endregion
        #region ÔÀÇÀ 4
        _topAttantion.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _middleAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _bottomAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);

        _boss.Attack(BossAttackType.TOP);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _topAttantion.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _boss.Attack(BossAttackType.MIDDLE);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _middleAttention.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _boss.Attack(BossAttackType.BOTTOM);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _bottomAttention.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(_pauseTime);
        yield return null;
        #endregion
        #region ÔÀÇÀ 5
        _obstacleSpawner.SpawnObstacle(ObstacleType.LOG, 1);
        yield return new WaitForSecondsRealtime(_pauseTime * 2);
        _bottomAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _boss.Attack(BossAttackType.BOTTOM);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _bottomAttention.gameObject.SetActive(false);
        yield return null;
        #endregion
        #region ÔÀÇÀ 6
        yield return new WaitForSecondsRealtime(BossAttackTime);
        _obstacleSpawner.SpawnObstacle(ObstacleType.ROCK,2);      
        _bottomAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);       
        _boss.Attack(BossAttackType.BOTTOM);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();       
        _bottomAttention.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(_pauseTime);      
        _middleAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _boss.Attack(BossAttackType.MIDDLE);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _middleAttention.gameObject.SetActive(false);
        yield return null;
        #endregion
        #region ÔÀÇÀ 7
        yield return new WaitForSecondsRealtime(BossAttackTime);
        _obstacleSpawner.SpawnObstacle(ObstacleType.LOG,2);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _topAttantion.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _obstacleSpawner.SpawnObstacle(ObstacleType.LOG, 1);
        _boss.Attack(BossAttackType.TOP);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _topAttantion.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _bottomAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
       
        yield return new WaitForSecondsRealtime(_pauseTime);
        _boss.Attack(BossAttackType.BOTTOM);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _bottomAttention.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(_pauseTime); 
       
        //
        _topAttantion.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _middleAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _boss.Attack(BossAttackType.TOP);
       
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _topAttantion.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _obstacleSpawner.SpawnObstacle(ObstacleType.ROCK,1);
        _boss.Attack(BossAttackType.MIDDLE);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _middleAttention.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(_pauseTime);      
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();       
        yield return new WaitForSecondsRealtime(_pauseTime*2);
        //
        _middleAttention.gameObject.SetActive(true);
        _bottomAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _boss.Attack(BossAttackType.MIDDLE);
        _boss.Attack(BossAttackType.BOTTOM);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _middleAttention.gameObject.SetActive(false);
        _bottomAttention.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(_pauseTime);

        _topAttantion.gameObject.SetActive(true);
        _middleAttention.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(_pauseTime);
        _boss.Attack(BossAttackType.TOP);
        _boss.Attack(BossAttackType.MIDDLE);
        yield return new WaitForSecondsRealtime(BossSlapTime);
        SoundsRoot.Instance.PlayBossAttackSoound();
        _camera.Shake();
        _topAttantion.gameObject.SetActive(false);
        _middleAttention.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(_pauseTime);
        yield return null;
        #endregion

        yield return new WaitForSecondsRealtime(3f);
        CheckCanChangeScene();
    }   
}
