using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteQuestByTrigger : MonoBehaviour
{
    public QuestSystem questSystem;
    public int needQuest;
    public GameObject wayPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем тег объекта
        {
            if (questSystem != null && questSystem.quest == needQuest) // Проверка на null и соответствие задания
            {
                questSystem.QuestComplete();
                wayPoint.SetActive(false);
            }
        }
    }
}
