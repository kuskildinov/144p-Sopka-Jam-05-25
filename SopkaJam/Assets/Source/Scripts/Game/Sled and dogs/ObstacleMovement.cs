using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float moveSpeed; // Скорость движения влево
    public float speedUp = 0.0001f;

    public void Initialize(float speed)
    {
        moveSpeed = speed;
    }
    void Update()
    {

        // Двигаем объект влево с постоянной скоростью
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        moveSpeed += speedUp;
        // Если объект ушёл за левую границу экрана
        if (transform.position.x < -12f)
        {
            Destroy(gameObject); // Уничтожаем камень
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Текст");
            Destroy(gameObject); // Уничтожаем камень
        }
    }
}
