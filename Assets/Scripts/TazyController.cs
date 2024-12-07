using UnityEngine;

public class DogController : MonoBehaviour
{
    public float moveSpeed = 3f; // �������� �������� ������
    public float rotationSpeed = 5f; // �������� �������� ������
    public Animator animator; // �������� ������
    public float offsetRadius = 2.0f; // ������ ���������� �� ����� �����
    public LayerMask terrainLayer; // ���� ��������
    private Vector3 targetPosition; // ����� ����� � ������ ����������
    private bool isMoving = false; // ��������� ��������

    private void Update()
    {
        // ��������� ���� ����
        if (Input.GetMouseButtonDown(0)) // ����� ������ ����
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, terrainLayer))
            {
                // ������������� ������� ������� � �����������
                targetPosition = hit.point + GetRandomOffset();
                isMoving = true;
            }
        }

        if (isMoving)
        {
            MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;

        // �������� ������
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // ������� ������ � ������� ����
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // �������� ��������
        animator.SetBool("isRun", true);

        // ���������, ���� ������ �������� ����
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
            animator.SetBool("isRun", false);
        }
    }

    private Vector3 GetRandomOffset()
    {
        // ��������� ���������� ���������� � �������� �������
        Vector2 randomCircle = Random.insideUnitCircle * offsetRadius;
        return new Vector3(randomCircle.x, 0, randomCircle.y);
    }

    public void DogComeToPlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, terrainLayer))
        {
            // ������������� ������� ������� � �����������
            targetPosition = hit.point + GetRandomOffset();
            isMoving = true;
        }
    }
}
