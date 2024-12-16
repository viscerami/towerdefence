using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLight : MonoBehaviour
{
    private Color originalColor;
    public Color highlightColor = Color.yellow; // Цвет подсветки

    private void Start()
    {
        // Сохраняем оригинальный цвет объекта
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            originalColor = renderer.material.color;
        }
    }

    private void OnMouseEnter()
    {
        // Меняем цвет на цвет подсветки при наведении мыши
        ChangeColor(highlightColor);
    }

    private void OnMouseExit()
    {
        // Возвращаем оригинальный цвет, когда мышь выходит
        ChangeColor(originalColor);
    }

    private void ChangeColor(Color newColor)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = newColor;
        }
    }
}
