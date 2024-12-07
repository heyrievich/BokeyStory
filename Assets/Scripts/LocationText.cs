using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAppear : MonoBehaviour
{
    public Animator anim;
    public TextMeshProUGUI text;
    public string locationName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем тег объекта
        {
            text.text = locationName;

            // Сбрасываем анимацию перед запуском
            anim.Rebind();
            anim.Update(0);

            // Запускаем анимацию
            anim.Play("LocationText");
        }
    }
}
