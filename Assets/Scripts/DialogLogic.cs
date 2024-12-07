using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogLogic : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;

    public Animator miniGameAnim;
    private int dialog;

    public TextMeshProUGUI words;
    public TextMeshProUGUI words2;

    public GameObject dialogPanel;
    public bool isClickable = false;

    public GameObject miniGamePanel;

    public GameObject BokeyDialog;

    public QuestSystem quest;

    public GameObject wayPoint;

    public PlayerController player;

    public Animator cloud;

    public AudioSource source;

    public AudioClip swoosh;
    public AudioClip note;

    public GameObject hint;



    // Update is called once per frame
    void Update()
    {
        if (isClickable)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                OpenDialog();
            }
        }
    }

    public void OpenDialog()
    {
        // ����������� ���� swoosh ��� �������� ������ ����������� ����
        source.PlayOneShot(swoosh);

        if (dialog == 0)
        {
            player.canWalk = false;
            words.text = "�����������������, ���!";
            OpenBokei();
            dialogPanel.SetActive(true);
            cloud.Play("New Animation");
        }
        else if (dialog == 1)
        {
            words2.text = "�����������������! ��� �� � ����� ������?";
            CloseBokei();
            Invoke("OpenBatyr", 1f);
        }

        else if (dialog == 2)
        {
            words.text = "���� ����� �����. ��� ���� ������, �� ��������. � ������ ��������� ������. ������ �� �� ���������� ���� �� ������ �����?";
            CloseBatyr();
            Invoke("OpenBokei", 1f);
            cloud.Play("CloseCloud");
        }
        else if (dialog == 3)
        {
            words2.text = "����� ������ �� ������ ���������. �� ���� ����: ���� ���� �����������. ���� �� �� ��������, � ������.";
            CloseBokei();
            Invoke("OpenBatyr", 1f);
        }
        else if (dialog == 4)
        {
            words.text = "�����, ���� ����. � ������ ���.";
            CloseBatyr();
            Invoke("OpenBokei", 1f);
        }

        else if (dialog == 5)
        {
            CloseBokei();
            miniGamePanel.SetActive(true);
            isClickable = false;
            miniGameAnim.Play("OpenMiniGame");
        }

        if (dialog >= 6)
        {
            CloseBatyr();
            Invoke("FinishDialog", 1f);
        }

        dialog++;
    }


    public void OpenBatyr()
    {
        anim2.Play("BatyrOpen");
    }

    public void OpenBokei()
    {
        anim.Play("BokeyOpen");
    }

    public void CloseBatyr()
    {
        anim2.Play("BatyrClose");
    }

    public void CloseBokei()
    {
        anim.Play("BokeyClose");
    }

    public void WinMiniGame()
    {
        source.PlayOneShot(note);
        isClickable = true;
        words2.text = "�������, ��������, ������ ���� ����. ��� ������� ��� ��� ����� ������. �� �������: ������� ���� ���� ������� ���������. ���� ���������.";
        Invoke("OpenBatyr", 1f);
        miniGameAnim.Play("CloseMiniGame");
    }

    private void FinishDialog()
    {
        player.canWalk = true;
        quest.QuestComplete();
        wayPoint.SetActive(true);
        hint.SetActive(true);
        Destroy(gameObject);

    }

}
