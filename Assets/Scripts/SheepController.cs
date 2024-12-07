using UnityEngine;

public class SheepController : MonoBehaviour
{
    public RectTransform moveArea; // Ссылка на панель, где овцы двигаются
    public RectTransform penArea; // Ссылка на загон
    private RectTransform rectTransform;
    public float speed = 100f; // Скорость движения овцы
    private bool isInPen = false; // Флаг для проверки, в загоне ли овца
    public Pen pen;

    [Header("Audio Settings")]
    public AudioSource audioSource; // AudioSource для овцы
    public AudioClip sheepSound; // Звук овцы

    private float nextSoundTime = 0f; // Время до следующего воспроизведения звука

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // Устанавливаем время до первого воспроизведения звука
        ScheduleNextSound();
    }

    private void Update()
    {
        if (isInPen) return; // Если овца в загоне, она не двигается

        // Движение овцы
        MoveSheep();

        // Проверяем, попала ли овца в загон
        CheckIfInPen();

        // Проверяем, пора ли воспроизводить звук
        PlaySheepSound();
    }

    private void MoveSheep()
    {
        Vector3 cursorPos = Input.mousePosition;
        Vector3 direction = (rectTransform.position - cursorPos).normalized;

        // Обновляем вращение овцы
        UpdateRotation(direction);

        // Двигаем овцу
        rectTransform.position += direction * speed * Time.deltaTime;

        // Ограничиваем движение в пределах панели
        ClampMovement();
    }

    private void ClampMovement()
    {
        Vector3 clampedPos = rectTransform.localPosition;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -moveArea.rect.width / 2, moveArea.rect.width / 2);
        clampedPos.y = Mathf.Clamp(clampedPos.y, -moveArea.rect.height / 2, moveArea.rect.height / 2);
        rectTransform.localPosition = clampedPos;
    }

    private void CheckIfInPen()
    {
        // Проверяем, находится ли овца в загоне
        if (RectTransformUtility.RectangleContainsScreenPoint(penArea, rectTransform.position))
        {
            // Фиксируем овцу внутри загона
            isInPen = true;
            LockSheepInPen();
        }
    }

    private void LockSheepInPen()
    {
        // Перемещаем овцу в центр загона и выключаем её движение
        Vector3 penCenter = penArea.position;
        rectTransform.position = penCenter;
        pen.UpdateSheepCount();
        // Устанавливаем овцу как дочерний объект загона
        rectTransform.SetParent(penArea);
    }

    private void UpdateRotation(Vector3 direction)
    {
        // Рассчитываем угол на основе направления движения
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Поворачиваем овцу, сохраняя исходный Z (глубину)
        rectTransform.rotation = Quaternion.Euler(0, 0, angle - 90); // "-90", чтобы овца смотрела вперёд по оси Y
    }

    private void PlaySheepSound()
    {
        if (Time.time >= nextSoundTime)
        {
            if (audioSource != null && sheepSound != null)
            {
                audioSource.PlayOneShot(sheepSound);
            }
            ScheduleNextSound();
        }
    }

    private void ScheduleNextSound()
    {
        nextSoundTime = Time.time + Random.Range(7f, 18f); // Рандомный интервал между звуками
    }

    public bool IsInPen()
    {
        return isInPen;
    }
}
