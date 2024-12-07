
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ссылка на персонажа
    public Vector3 offset = new Vector3(0, 5, -10); // Ракурс камеры

    void LateUpdate()
    {
        if (target != null)
        {
            // Позиция камеры с учетом смещения
            transform.position = target.position + offset;

            // Смотрим на персонажа
            transform.LookAt(target);
        }
    }
}
