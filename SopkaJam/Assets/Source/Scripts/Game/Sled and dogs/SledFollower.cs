using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SledFollower : MonoBehaviour
{
    [Header("Settings")]
    public Transform player;          // Ссылка на персонажа
    public float minFollowSpeed = 2f; // Базовая скорость
    public float maxFollowSpeed = 8f; // Макс. скорость при отставании
    public float maxDistance = 3f;    // Дистанция для ускорения
    public float smoothTime = 0.1f;   // Плавность движения

    private Rigidbody2D rb;
    private Vector2 currentVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.isKinematic = false; // Разрешаем двигаться через velocity
    }

    void FixedUpdate()
    {
        if (player == null) return;

        // Только вертикальное движение (X остаётся неизменным)
        Vector2 targetPosition = new Vector2(transform.position.x, player.position.y);

        // Дистанция до игрока по вертикали
        float distance = Mathf.Abs(player.position.y - transform.position.y);

        // Динамическая скорость: чем дальше, тем быстрее
        float speed = Mathf.Lerp(minFollowSpeed, maxFollowSpeed, distance / maxDistance);

        // Плавное перемещение
        Vector2 newPosition = Vector2.SmoothDamp(
            transform.position,
            targetPosition,
            ref currentVelocity,
            smoothTime,
            speed
        );

        rb.MovePosition(newPosition);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("-1hp");
            Destroy(collision.gameObject); // Уничтожаем камень
        }
    }
}
