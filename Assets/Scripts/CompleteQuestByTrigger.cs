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
        if (other.CompareTag("Player")) // ��������� ��� �������
        {
            if (questSystem != null && questSystem.quest == needQuest) // �������� �� null � ������������ �������
            {
                questSystem.QuestComplete();
                wayPoint.SetActive(false);
            }
        }
    }
}
