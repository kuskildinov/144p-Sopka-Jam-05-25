using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения влево

    void Update()
    {
        // Двигаем объект влево с постоянной скоростью
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }
}
