using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Префаб препятствия
    public float spawnInterval = 2f; // Интервал между спавном
    public float spawnDistance = 10f; // Дистанция перед игроком
    public float minY = -2f, maxY = 2f; // Разброс по высоте
    public Transform player; // Ссылка на игрока

    private float timer;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0;
        }
    }

    void SpawnObstacle()
    {
        // Позиция спавна: перед игроком + случайная высота
        Vector3 spawnPos = new Vector3(
            player.position.x + spawnDistance,
            Random.Range(minY, maxY),
            0
        );

        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
