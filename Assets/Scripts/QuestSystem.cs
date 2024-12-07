using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class QuestSystem : MonoBehaviour
{
    public TextMeshProUGUI questName; // �������� ������
    public TextMeshProUGUI questAim;  // ���� ������
    public TextMeshProUGUI questDesc; // �������� ������

    public int quest = 1; // ������� ����� ������
    public Animator questAnimator; // �������� ��� �������� ��������/��������
    private bool isQuestOpen = false; // ������ ���������� ����

    public PauseMenu pauseMenu;

    public Animator anim;

    public AudioSource source;
    public AudioSource source2;
    public AudioClip paper; // ���� ����� �� �����
    public AudioClip complete;
    public AudioClip swoosh;

    void Start()
    {

        QuestTextUpdate();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isQuestOpen)
            {
                CloseQuestMenu();
            }
            else
            {
                OpenQuestMenu();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.PauseGame();
            source.PlayOneShot(swoosh);
        }

    }


    public void QuestTextUpdate()
    {
        switch (quest)
        {
            case 1:
                questName.text = "������� - 1";
                questAim.text = "���� - ������� �� ����������� �����";
                questDesc.text = "���� ������ ��������, � ��� ����� �� ��������. � ������, ��� ���������� ���� ����������� ����� � ����� ��� ���������.";
                break;
            case 2:
                questName.text = "������� - 2";
                questAim.text = "���� - ������� 4 ��������";
                questDesc.text = "������ �� ����������� �����, �, � ���������, �� ����� �� ���, �� ����. ������ ��������� ��������� ������ �����, ����������� ��� ����� ����������.";
                break;
            case 3:
                questName.text = "������� - 3";
                questAim.text = "���� - �������� ������ ����";
                questDesc.text = "� ������ ��������� ���, �������� ��� ����� ����� ��, ��� ����� ������ ����. ��������� � ��������� �� ���� ������� ���.";
                break;
            case 4:
                questName.text = "������� - 4";
                questAim.text = "���� - ���������� � �������";
                questDesc.text = "� �������� ���� � ����� ���� ����. �������, ��� ������ ��� ������. � ���� ��������� �������, ����� � ���� ����������.";
                break;
            case 5:
                questName.text = "������� - 5";
                questAim.text = "���� - �������� �����";
                questDesc.text = "� �������� ��� � ��� ���� ���. � ����� �������� ��, ��������, ������ ������ � ��������� �� �������� ������. ������ �������� ������ ��������� � ����.";
                break;
            case 6:
                questName.text = "������� - 6";
                questAim.text = "���� - ������ ��� ����";
                questDesc.text = "� �������� ���. �������� ���� ������ ��� ����. ������� ��� ���������� ������.";
                break;
            case 7:
                questName.text = "������� - 7";
                questAim.text = "���� - ���������� � �����";
                questDesc.text = "��� �������, � ���� ���-�� ��������. ����� ���������� � ����� � ������� ��� ������� ������� �����. ��� ������������ ������ �������� ���� � ���� ������ ������.";
                break;
            default:
                questName.text = "����� ��������!";
                questAim.text = "";
                questDesc.text = "�����������, �� ��������� ��� �������!";


                break;

        }
    }


    public void QuestComplete()
    {
        if (quest <= 8)
        {
            quest++;
            QuestTextUpdate();
            OpenQuestMenu();
         
        }



    }


    private void OpenQuestMenu()
    {
        isQuestOpen = true;
        questAnimator.Play("QuestOpen");
        source.PlayOneShot(paper);
    }

    private void CloseQuestMenu()
    {

        isQuestOpen = false;
        questAnimator.Play("QuestClose");
        source.PlayOneShot(paper);
    }


    public void FinalCLose()
    {
        anim.Play("FinalClose");
    }
}
