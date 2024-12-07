using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogWithHan : MonoBehaviour
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

    public Animator animCutScene;




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
            words.text = "Здравствуй Хан!";
            OpenBokei();
            dialogPanel.SetActive(true);
            cloud.Play("New Animation");
        }
        else if (dialog == 1)
        {
            words2.text = "Что привело тебя сюда, Бөкей?";
            CloseBokei();
            Invoke("OpenBatyr", 1f);
        }

        else if (dialog == 2)
        {
            words.text = "Спасибо, что помог мне, о великий хан. Но я не хочу быть эгоистом — весь народ голодает. Прошу, помоги нам, иначе люди погибнут.";
            CloseBatyr();
            Invoke("OpenBokei", 1f);
            cloud.Play("CloseCloud");
        }

        else if (dialog == 3)
        {
            words2.text = "В твоих словах есть смысл. Что я должен сделать, чтобы облегчить страдания народа?";
            CloseBokei();
            Invoke("OpenBatyr", 1f);
        }

        else if (dialog == 4)
        {
            words.text = "Созови ханский совет. Пусть уазыры предложат пути спасения: помощь голодающим, защита скота, торговля с соседями. Время не ждёт.";
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
        source.PlayOneShot(note);
        animCutScene.Play("Final");
        Invoke("FinalCatScene", 1.5f);
    }

    private void FinalCatScene()
    {
        SceneManager.LoadScene("Final");
    }

}
