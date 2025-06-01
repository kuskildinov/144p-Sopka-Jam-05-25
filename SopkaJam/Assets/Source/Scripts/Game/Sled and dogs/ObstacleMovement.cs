using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float moveSpeed; // Скорость движения влево
    public float speedUp =0f;

    void Start()
    {
        
    }
    public void Initialize(float speed)
    {
        moveSpeed = speed;

        if (gameObject.name == "Beam_sc8(Clone)" && transform.position.y > -2.1f)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.y = -1.15f;
            transform.localScale = currentScale;
        }
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
