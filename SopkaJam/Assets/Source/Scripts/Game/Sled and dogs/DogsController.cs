using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogsController : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed = 5f;       // Скорость обычного движения
    public float dashSpeed = 10f;      // Скорость рывка
    public float dashDuration = 0.15f; // Длительность рывка
    public float dashCooldown = 1f;    // Перезарядка

    private Rigidbody2D rb;
    private bool isDashing;
    private float lastDashTime;
    private float originalGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale;
        rb.gravityScale = 0; // Отключаем гравитацию
    }

    void Update()
    {
        // Обычное движение вверх/вниз
        if (!isDashing)
        {
            float verticalInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(0, verticalInput * moveSpeed);
        }

        // Рывок по нажатию Shift
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing && Time.time > lastDashTime + dashCooldown)
        {
            float dashDirection = Input.GetAxisRaw("Vertical");
            if (dashDirection != 0) // Рывок только при движении
            {
                StartCoroutine(Dash(dashDirection));
            }
        }
    }

    IEnumerator Dash(float direction)
    {
        isDashing = true;
        lastDashTime = Time.time;

        // Фиксируем направление рывка
        rb.velocity = new Vector2(0, direction * dashSpeed);

        // Визуальный эффект (можно добавить частицы)
        GetComponent<SpriteRenderer>().color = Color.blue;

        yield return new WaitForSeconds(dashDuration);

        // Возвращаем обычное состояние
        rb.velocity = Vector2.zero;
        GetComponent<SpriteRenderer>().color = Color.white;
        isDashing = false;
    }

}
