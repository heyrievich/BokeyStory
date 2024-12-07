using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogWithMom : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;

    private int dialog = 0;

    public TextMeshProUGUI words;
    public TextMeshProUGUI words2;

    public GameObject dialogPanel;
    public bool isClickable = false;

    public PlayerController player;

    public Animator cloud;

    public AudioSource source;

    public AudioClip swoosh;
    public AudioClip note;

    public QuestSystem quest;

    public GameObject hint;
    public GameObject navigator;
    public GameObject khan;


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
        // Проигрываем звук swoosh при открытии любого диалогового окна
        source.PlayOneShot(swoosh);

        if (dialog == 0)
        {
            player.canWalk = false;
            words.text = "Анашым, смотри я принес еду, его дал мне хан.";
            OpenBokei();
            dialogPanel.SetActive(true);
            cloud.Play("New Animation");
        }
        else if (dialog == 1)
        {
            words2.text = "Бөкей, хан приехал. Это шанс донести до него страдания народа.";
            CloseBokei();
            Invoke("OpenBatyr", 1f);
        }

        else if (dialog == 2)
        {
            words.text = "Что ты хочешь, мама?";
            CloseBatyr();
            Invoke("OpenBokei", 1f);
            cloud.Play("CloseCloud");
        }

        else if (dialog == 3)
        {
            words2.text = "Иди к нему. Скажи, как тяжело людям, Созовите Ханский совет.";
            CloseBokei();
            Invoke("OpenBatyr", 1f);
        }

        else if (dialog == 4)
        {
            words.text = "Хорошо, мама. Я сделаю это.";
            CloseBatyr();
            Invoke("OpenBokei", 1f);
        }


        if (dialog >= 5)
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

    private void FinishDialog()
    {
        player.canWalk = true;
        Destroy(gameObject);
        source.PlayOneShot(note);
        navigator.SetActive(true);
        hint.SetActive(false);
        khan.SetActive(true);
        quest.QuestComplete();
    }

}
