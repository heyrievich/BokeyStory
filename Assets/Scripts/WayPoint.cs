using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    [Header("Objects")]
    public Transform character; // Персонаж
    public Transform target; // Цель

    [Header("UI Elements")]
    public TextMeshProUGUI distanceText; // Текст для отображения расстояния
    public RectTransform arrow; // Стрелка на Canvas

    private bool isTrackingEnabled = true;

    void Update()
    {
        if (isTrackingEnabled)
        {
            UpdateDistanceText();
            UpdateArrowDirection();
        }
    }

    /// <summary>
    /// Включить обновление текста и стрелки.
    /// </summary>
    public void EnableTracking()
    {
        isTrackingEnabled = true;
        distanceText.gameObject.SetActive(true);
    }

    /// <summary>
    /// Выключить обновление текста и стрелки.
    /// </summary>
    public void DisableTracking()
    {
        isTrackingEnabled = false;
        distanceText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Обновляет текст расстояния.
    /// </summary>
    private void UpdateDistanceText()
    {
        float distance = Vector3.Distance(character.position, target.position);
        distanceText.text = $"{distance:F2} метров";
    }

    /// <summary>
    /// Обновляет направление стрелки.
    /// </summary>
    private void UpdateArrowDirection()
    {
        Vector3 direction = target.position - character.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; // Угол поворота в градусах
        arrow.rotation = Quaternion.Euler(0, 0, -angle); // Поворот стрелки
    }
}
