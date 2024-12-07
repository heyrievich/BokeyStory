using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // ��� ������ � Image �����������
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

    public Image artefactImage; // Image ��� ����������� ���������
    public Sprite artefactSprite1; // ������ ��� ������� ���������
    public Sprite artefactSprite2; // ������ ��� ������� ���������
    public Sprite artefactSprite3; // ������ ��� �������� ���������
    public Sprite artefactSprite4; // ������ ��� ���������� ���������
    public Sprite kostSprite; // ������ ��� ���������� ���������

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
        itemName.text = "�����";
        itemDesc.text = "����� � ��� ������� ������ ������, ������� ������ �������������� � ������������ ����� ������� ����������. ��� ������� �� ����, ����� ������ �����, ���� ������ � ������� ������������.";
        artefactImage.sprite = artefactSprite1; // ������������� ������ ������� ���������
        InfoOpen();
        player.currentTriggerTag = "";
        player.canWalk = false;
        isKost = false;
    }

    public void Artefact2Found()
    {
        ItemAdd();
        Destroy(artefact2);
        itemName.text = "�����";
        itemDesc.text = "����� - ��� ��� ��������� ������, ������� �������� ������ ����� � ������� ���������� ������ � ������ �����-����������. ��� ���� ���������� ��������� �������, ������� �� ������ �������, �� � �������� ��������, �������� � �����.";
        artefactImage.sprite = artefactSprite2; // ������������� ������ ������� ���������
        InfoOpen();
        player.currentTriggerTag = "";
        player.canWalk = false;
        isKost = false;
    }

    public void Artefact3Found()
    {
        ItemAdd();
        Destroy(artefact3);
        itemName.text = "�����";
        itemDesc.text = "����� � ��� ���� �� �������� ������ ������� ����������, ����������� ������ �������� ���, ���������������� � ������� � ���������� �����. ��� ������� ������ ����� � ������� ���������� ������ ��� ������ ���������, ��������, ���������� � ��������.";
        artefactImage.sprite = artefactSprite3; // ������������� ������ �������� ���������
        InfoOpen();
        player.currentTriggerTag = "";
        player.canWalk = false;
        isKost = false;
    }

    public void Artefact4Found()
    {
        ItemAdd();
        Destroy(artefact4);
        itemName.text = "�������";
        itemDesc.text = "������� � ��� ������ ������� �������� �������� ���� ���������� ������. ����� � ����� ���������� ���� �� ������ ����������� ���������, �� � ���������� ���������, �������� � ����������.";
        artefactImage.sprite = artefactSprite4; // ������������� ������ ���������� ���������
        InfoOpen();
        player.currentTriggerTag = "";
        player.canWalk = false;
        isKost = false;
    }

    public void KostFound()
    {
        ItemAdd();
        Destroy(kost);
        itemName.text = "������� �����";
        itemDesc.text = "???";
        artefactImage.sprite = kostSprite; // ������������� ������ ���������� ���������
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
