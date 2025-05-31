using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float[] layerSpeeds; // Скорости для каждого слоя
    private Transform[] layers;  // Ссылки на слои
    public float spriteWidth = 48f;

    void Start()
    {
        // Получаем все дочерние объекты (слои)
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        // Двигаем каждый слой с своей скоростью
        for (int i = 0; i < layers.Length; i++)
        {
            float speed = layerSpeeds[i];
            layers[i].position += Vector3.left * speed * Time.deltaTime;

            // Телепортация слоя для бесконечности
            if (layers[i].position.x < -48) // Укажи нужное значение
            {
                layers[i].position += Vector3.right * (spriteWidth * 2); // Смести вперёд
            }
        }
    }
}
