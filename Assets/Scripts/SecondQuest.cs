using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Для работы с Image компонентом
using TMPro;

public class SecondQuest : MonoBehaviour
{
    private int itemsCount = 0;
    public QuestSystem questSystem;
    public GameObject artefact1;
    public GameObject artefact2;
    public GameObject artefact3;
    public GameObject artefact4;
    public GameObject kost;

    public GameObject wayPoint;

    public PlayerController player;

    public Animator animator;

    public Animator catScene;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDesc;

    public Image artefactImage; // Image для отображения артефакта
    public Sprite artefactSprite1; // Спрайт для первого артефакта
    public Sprite artefactSprite2; // Спрайт для второго артефакта
    public Sprite artefactSprite3; // Спрайт для третьего артефакта
    public Sprite artefactSprite4; // Спрайт для четвертого артефакта
    public Sprite kostSprite; // Спрайт для четвертого артефакта

    private bool isOpen;

    public AudioSource source;
    public AudioSource natureSource;
    public AudioClip dogSound;

    public GameObject tazy;

    private bool isKost = false;

    public DialogWithDog dialogWithDog;

    public DogController dog;


    void Update()
    {
        if (isOpen)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (!isKost)
                {
                    animator.Play("ItemInfoClose");
                    isOpen = false;
                    player.canWalk = true;
                    ItemCountCheck();
                }

                if (isKost)
                {
                    DogArrive();
                    animator.Play("ItemInfoClose");
                    isOpen = false;
                    player.canWalk = true;
                    

                }
            }
        }

    }

    public void ItemCountCheck()
    {
        if (itemsCount == 5)
        {
            catScene.Play("GamePlayScene");
            Invoke("ASourcePlay", 1.5f);
            Invoke("LevelIsComplete", 9);
        }
    }


    private void LevelIsComplete()
    {
        natureSource.Play();
        questSystem.QuestComplete();
        wayPoint.SetActive(true);
        
    }

    private void ASourcePlay()
    {
        natureSource.Stop();
        source.Play();
    }

    private void ItemAdd()
    {
        itemsCount++;
    }

    public void Artefact1Found()
    {
        ItemAdd();
        Destroy(artefact1);
        itemName.text = "Камшы";
        itemDesc.text = "Камшы – это изделие ручной работы, которое широко использовалось в повседневной жизни древних кочевников. Оно плелось из кожи, имело разную длину, было гибким и прочным инструментом.";
        artefactImage.sprite = artefactSprite1; // Устанавливаем спрайт первого артефакта
        InfoOpen();
        player.currentTriggerTag = "";
        player.canWalk = false;
        isKost = false;
    }

    public void Artefact2Found()
    {
        ItemAdd();
        Destroy(artefact2);
        itemName.text = "Кылыш";
        itemDesc.text = "Кылыш - это вид холодного оружия, который занимает особое место в истории казахского народа и вообще тюрко-кочевников. Она была неизменным спутником батыров, служила не только оружием, но и символом доблести, героизма и чести.";
        artefactImage.sprite = artefactSprite2; // Устанавливаем спрайт второго артефакта
        InfoOpen();
        player.currentTriggerTag = "";
        player.canWalk = false;
        isKost = false;
    }

    public void Artefact3Found()
    {
        ItemAdd();
        Destroy(artefact3);
        itemName.text = "Садак";
        itemDesc.text = "Садак – это одно из основных орудий древних кочевников, эффективное оружие дальнего боя, использовавшееся в военных и охотничьих целях. Лук занимал особое место в истории казахского народа как символ храбрости, меткости, мастерства и ловкости.";
        artefactImage.sprite = artefactSprite3; // Устанавливаем спрайт третьего артефакта
        InfoOpen();
        player.currentTriggerTag = "";
        player.canWalk = false;
        isKost = false;
    }

    public void Artefact4Found()
    {
        ItemAdd();
        Destroy(artefact4);
        itemName.text = "Ертокым";
        itemDesc.text = "Ертокым – это важный элемент культуры верховой езды казахского народа. Седло в жизни кочевников было не только необходимым предметом, но и отражением искусства, традиций и мастерства.";
        artefactImage.sprite = artefactSprite4; // Устанавливаем спрайт четвертого артефакта
        InfoOpen();
        player.currentTriggerTag = "";
        player.canWalk = false;
        isKost = false;
    }

    public void KostFound()
    {
        ItemAdd();
        Destroy(kost);
        itemName.text = "Обычная кость";
        itemDesc.text = "???";
        artefactImage.sprite = kostSprite; // Устанавливаем спрайт четвертого артефакта
        InfoOpen();
        player.currentTriggerTag = "";
        player.canWalk = false;
        isKost = true;

    }

    private void InfoOpen()
    {
        isOpen = true;
        animator.Play("ItemInfoOpen");
    }

    private void DogArrive()
    {
        source.PlayOneShot(dogSound);
        tazy.SetActive(true);
        dog.DogComeToPlayer();
        dialogWithDog.OpenDialog();
        dialogWithDog.isClickable = true;
        
    }

}
