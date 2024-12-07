using UnityEngine;

public class DogController : MonoBehaviour
{
    public float moveSpeed = 3f; // Скорость движения собаки
    public float rotationSpeed = 5f; // Скорость поворота собаки
    public Animator animator; // Аниматор собаки
    public float offsetRadius = 2.0f; // Радиус отклонения от точки клика
    public LayerMask terrainLayer; // Слой террейна
    private Vector3 targetPosition; // Точка клика с учетом отклонения
    private bool isMoving = false; // Состояние движения

    private void Update()
    {
        // Проверяем клик мыши
        if (Input.GetMouseButtonDown(0)) // Левая кнопка мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, terrainLayer))
            {
                // Устанавливаем целевую позицию с отклонением
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

        // Движение собаки
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Поворот собаки в сторону цели
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // Анимация движения
        animator.SetBool("isRun", true);

        // Остановка, если собака достигла цели
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
            animator.SetBool("isRun", false);
        }
    }

    private Vector3 GetRandomOffset()
    {
        // Генерация случайного отклонения в пределах радиуса
        Vector2 randomCircle = Random.insideUnitCircle * offsetRadius;
        return new Vector3(randomCircle.x, 0, randomCircle.y);
    }

    public void DogComeToPlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, terrainLayer))
        {
            // Устанавливаем целевую позицию с отклонением
            targetPosition = hit.point + GetRandomOffset();
            isMoving = true;
        }
    }
}
