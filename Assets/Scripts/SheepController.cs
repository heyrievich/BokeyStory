using UnityEngine;

public class SheepController : MonoBehaviour
{
    public RectTransform moveArea; // ������ �� ������, ��� ���� ���������
    public RectTransform penArea; // ������ �� �����
    private RectTransform rectTransform;
    public float speed = 100f; // �������� �������� ����
    private bool isInPen = false; // ���� ��� ��������, � ������ �� ����
    public Pen pen;

    [Header("Audio Settings")]
    public AudioSource audioSource; // AudioSource ��� ����
    public AudioClip sheepSound; // ���� ����

    private float nextSoundTime = 0f; // ����� �� ���������� ��������������� �����

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // ������������� ����� �� ������� ��������������� �����
        ScheduleNextSound();
    }

    private void Update()
    {
        if (isInPen) return; // ���� ���� � ������, ��� �� ���������

        // �������� ����
        MoveSheep();

        // ���������, ������ �� ���� � �����
        CheckIfInPen();

        // ���������, ���� �� �������������� ����
        PlaySheepSound();
    }

    private void MoveSheep()
    {
        Vector3 cursorPos = Input.mousePosition;
        Vector3 direction = (rectTransform.position - cursorPos).normalized;

        // ��������� �������� ����
        UpdateRotation(direction);

        // ������� ����
        rectTransform.position += direction * speed * Time.deltaTime;

        // ������������ �������� � �������� ������
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
        // ���������, ��������� �� ���� � ������
        if (RectTransformUtility.RectangleContainsScreenPoint(penArea, rectTransform.position))
        {
            // ��������� ���� ������ ������
            isInPen = true;
            LockSheepInPen();
        }
    }

    private void LockSheepInPen()
    {
        // ���������� ���� � ����� ������ � ��������� � ��������
        Vector3 penCenter = penArea.position;
        rectTransform.position = penCenter;
        pen.UpdateSheepCount();
        // ������������� ���� ��� �������� ������ ������
        rectTransform.SetParent(penArea);
    }

    private void UpdateRotation(Vector3 direction)
    {
        // ������������ ���� �� ������ ����������� ��������
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ������������ ����, �������� �������� Z (�������)
        rectTransform.rotation = Quaternion.Euler(0, 0, angle - 90); // "-90", ����� ���� �������� ����� �� ��� Y
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
        nextSoundTime = Time.time + Random.Range(7f, 18f); // ��������� �������� ����� �������
    }

    public bool IsInPen()
    {
        return isInPen;
    }
}
