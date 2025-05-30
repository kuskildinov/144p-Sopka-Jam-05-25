using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovment : MonoBehaviour
{
   [SerializeField] private Renderer _renderer;
    public float scrollSpeedX = 0.5f;
    public float scrollSpeedY = 0.5f;

    private Vector2 _offset;

    void Update()
    {
        // Смещение UV-координат
        _offset.x += Time.deltaTime * scrollSpeedX;
        _offset.y += Time.deltaTime * scrollSpeedY;

        // Применяем смещение к материалу
        _renderer.material.mainTextureOffset = _offset;
    }
}
