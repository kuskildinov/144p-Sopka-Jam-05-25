using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToEnd : MonoBehaviour
{
    private float _timeLeft = 60f; 

    public Transform house;      
    public float moveSpeed = 5f; 
    public float targetX = 0f;

    public bool _timeIsOver = false;
    public bool _shouldMove = false;
    public bool _stopHouse = false;

    void Update()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
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
        }

        if (_shouldMove && house.position.x > targetX)
        {           
            house.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
}
