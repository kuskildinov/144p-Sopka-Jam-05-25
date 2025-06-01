using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public ObstacleMovement[] obstaclePrefab; // Префаб препятствия
    public float spawnInterval = 2f; // Интервал между спавном
    public float minY = -2f, maxY = 2f; // Разброс по высоте
    public Transform player; // Ссылка на игрока
    public float startSpeed;
    public float speedUp = 0f;

    public TimerToEnd timerToEnd;
    private bool timerEnd;

    private float timer;
    private float currentSpeed;
    [SerializeField] public float beamPos = 0f;

    void Start()
    {
        currentSpeed = startSpeed;
    }

    void Update()
    {
        timerEnd = timerToEnd._timeIsOver;

        currentSpeed += speedUp;
        timer += Time.deltaTime;

        if (timer >= spawnInterval && timerEnd == false)
        {
            SpawnObstacle();
            timer = 0;
        }
    }

    void SpawnObstacle()
    {
        int rObst = Random.Range(0, obstaclePrefab.Length);
        Vector3 spawnPos = new Vector3(0,0,0);

        //rObst = 1;

        if (rObst == 0)
        {
            spawnPos = new Vector3(12, Random.Range(-4.46f, -0.17f), 0);
            beamPos = 0f;
        }
        else if (rObst == 1)
        {
            int rPos = Random.Range(0, 2);

            if(beamPos == 1f)
            {
                rPos = 1;
                beamPos = -4f;
            }
            else if (beamPos == -1f)
            {
                rPos = 0;
                beamPos = 4f;
            }


            if (rPos == 0 && beamPos >=0f)
            {
                spawnPos = new Vector3( 12, -1.04f, 0);
                if (beamPos == 1f) 
                    beamPos = -1f;
                else beamPos = 1f;


            }
            else if (rPos == 1 && beamPos <= 0f)
            {
                spawnPos = new Vector3(12, -4.1f, 0);
                
                if (beamPos == -1f) 
                    beamPos = 1f;
                else beamPos = -1f;
            }
        
        }
        
        
        ObstacleMovement Obstacle = Instantiate(obstaclePrefab[rObst], spawnPos, Quaternion.identity);
        Obstacle.Initialize(currentSpeed);
    }
}
