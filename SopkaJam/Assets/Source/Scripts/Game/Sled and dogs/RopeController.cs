using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    [Header("References")]
    public Transform player;  // Персонаж
    public Transform box;    // Ящик
    public LineRenderer rope;

    [Header("Settings")]
    public float ropeWidth = 0.1f;
    public float ropeSagHeight = 0.5f; // Провисание верёвки
    public int segments = 10;          // Количество сегментов для плавности

    void Start()
    {
        rope.positionCount = segments + 1;
        rope.startWidth = ropeWidth;
        rope.endWidth = ropeWidth * 0.5f;
    }

    void Update()
    {
        DrawRope();
    }

    void DrawRope()
    {
        Vector3 startPos = player.position;
        Vector3 endPos = box.position;

        // Рассчитываем контрольную точку для провисания (парабола)
        Vector3 midPoint = (startPos + endPos) / 2 + Vector3.down * ropeSagHeight;

        // Рисуем кривую Безье
        for (int i = 0; i <= segments; i++)
        {
            float t = i / (float)segments;
            Vector3 point = CalculateBezierPoint(t, startPos, midPoint, endPos);
            rope.SetPosition(i, point);
        }
    }

    Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        // Квадратичная кривая Безье
        return Mathf.Pow(1 - t, 2) * p0 +
               2 * (1 - t) * t * p1 +
               Mathf.Pow(t, 2) * p2;
    }
}
