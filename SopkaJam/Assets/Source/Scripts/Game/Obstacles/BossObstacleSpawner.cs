using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float _obstaclsSpeed;
    [Header("Obstacle Prefabs")]
    [SerializeField] private Obstacle _rockPrefab;
    [SerializeField] private Obstacle _snowdriftPrefab;
    [SerializeField] private Obstacle _logPrefab;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    public void SpawnObstacle(ObstacleType type, int lineIndex)
    {
        Obstacle obstacle = null;
        switch (type)
        {
            case ObstacleType.ROCK:
                {
                    obstacle = Instantiate(_rockPrefab,transform);
                    break;
                }
            case ObstacleType.SNOW:
                {
                    obstacle = Instantiate(_rockPrefab, transform);                   
                    break;
                }
            case ObstacleType.LOG:
                {
                    obstacle = Instantiate(_rockPrefab, transform);                  
                    break;
                }
        }

        if (obstacle == null || GetPositionByIndex(lineIndex) == Vector3.zero)
            return;

        obstacle.Initialize(_obstaclsSpeed);
        obstacle.transform.localPosition = GetPositionByIndex(lineIndex);
    }

    private Vector3 GetPositionByIndex(int index)
    {
        if(index == 1)
        {
            return _spawnPoints[0].localPosition;
        }
        else if(index == 2)
        {
            return _spawnPoints[1].localPosition;
        }
        else if (index == 3)
        {
            return _spawnPoints[2].localPosition;
        }
        else
        {
            Debug.LogError("Õ≈¬≈–ÕŒ ” ¿«¿Õ¿ À»Õ»ﬂ ƒÀﬂ —œ¿¬Õ¿");
            return Vector3.zero;
        }
    }

    private IEnumerator SpawnRoutine()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(2f);
            SpawnObstacle(ObstacleType.ROCK,2);
        }
    }
}

public enum ObstacleType
{ 
    ROCK,
    SNOW,
    LOG,
}

