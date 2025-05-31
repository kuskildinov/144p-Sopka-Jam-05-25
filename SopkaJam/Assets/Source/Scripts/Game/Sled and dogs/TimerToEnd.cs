using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToEnd : MonoBehaviour
{
    private float _timeLeft = 60f; // 60 секунд

    public Transform house;         // Ссылка на объект дома
    public float moveSpeed = 5f;   // Скорость движения дома
    public float targetX = 0f;     // Конечная позиция (X)

    public bool _timeIsOver = false;
    public bool _shouldMove = false;
    public bool _stopHouse = false;

    void Update()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime; // Уменьшаем время каждый кадр
        }
        else
        {

            Debug.Log("Время вышло!");
            _timeIsOver = true;
            _timeLeft -= Time.deltaTime;

            if (_timeLeft < -3)
            {
                _shouldMove = true;
            }
            
            if (house.position.x <= targetX)
            {
                _stopHouse = true;
            }
            // Здесь можно добавить свои действия
            //enabled = false; // Выключаем таймер
        }

        if (_shouldMove && house.position.x > targetX)
        {
            // Плавно двигаем дом влево
            house.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
}
