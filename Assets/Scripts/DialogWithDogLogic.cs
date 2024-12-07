using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogWithDog : MonoBehaviour
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

    public SecondQuest quest;



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
            words.text = "Что?!";
            OpenBokei();
            dialogPanel.SetActive(true);
            cloud.Play("New Animation");
        }
        else if (dialog == 1)
        {
            words2.text = "Гав-гав!";
            CloseBokei();
            Invoke("OpenBatyr", 1f);
        }

        else if (dialog == 2)
        {
            words.text = "Кажется, это тазы! Не бойся, я не причиню тебе вреда. Ты, наверное, проголодался? Вот тебе кость.";
            CloseBatyr();
            Invoke("OpenBokei", 1f);
            cloud.Play("CloseCloud");
        }
       
        if (dialog >= 3)
        {
            CloseBokei();
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
        quest.ItemCountCheck();
    }

}
