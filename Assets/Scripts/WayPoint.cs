using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    [Header("Objects")]
    public Transform character; // ��������
    public Transform target; // ����

    [Header("UI Elements")]
    public TextMeshProUGUI distanceText; // ����� ��� ����������� ����������
    public RectTransform arrow; // ������� �� Canvas

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
    /// �������� ���������� ������ � �������.
    /// </summary>
    public void EnableTracking()
    {
        isTrackingEnabled = true;
        distanceText.gameObject.SetActive(true);
    }

    /// <summary>
    /// ��������� ���������� ������ � �������.
    /// </summary>
    public void DisableTracking()
    {
        isTrackingEnabled = false;
        distanceText.gameObject.SetActive(false);
    }

    /// <summary>
    /// ��������� ����� ����������.
    /// </summary>
    private void UpdateDistanceText()
    {
        float distance = Vector3.Distance(character.position, target.position);
        distanceText.text = $"{distance:F2} ������";
    }

    /// <summary>
    /// ��������� ����������� �������.
    /// </summary>
    private void UpdateArrowDirection()
    {
        Vector3 direction = target.position - character.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg; // ���� �������� � ��������
        arrow.rotation = Quaternion.Euler(0, 0, -angle); // ������� �������
    }
}
