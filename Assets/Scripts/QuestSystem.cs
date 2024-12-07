using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class QuestSystem : MonoBehaviour
{
    public TextMeshProUGUI questName; // Название квеста
    public TextMeshProUGUI questAim;  // Цель квеста
    public TextMeshProUGUI questDesc; // Описание квеста

    public int quest = 1; // Текущий номер квеста
    public Animator questAnimator; // Аниматор для анимаций открытия/закрытия
    private bool isQuestOpen = false; // Статус квестового меню

    public PauseMenu pauseMenu;

    public Animator anim;

    public AudioSource source;
    public AudioSource source2;
    public AudioClip paper; // Звук шагов на траве
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
                questName.text = "Задание - 1";
                questAim.text = "Цель - сходить на заброшенный базар";
                questDesc.text = "Мать сильно заболела, а еды почти не осталось. Я слышал, что поблизости есть заброшенный базар — нужно его разведать.";
                break;
            case 2:
                questName.text = "Задание - 2";
                questAim.text = "Цель - изучить 4 предмета";
                questDesc.text = "Прибыв на заброшенный базар, я, к сожалению, не нашел ни еды, ни воды. Однако обнаружил несколько важных вещей, необходимых для жизни кочевников.";
                break;
            case 3:
                questName.text = "Задание - 3";
                questAim.text = "Цель - Отыскать лагерь Хана";
                questDesc.text = "В далеке виднеется дым, возможно там можно найти то, что может помочь маме. Поспешите и проверьте от чего исходит дым.";
                break;
            case 4:
                questName.text = "Задание - 4";
                questAim.text = "Цель - поговорить с батыром";
                questDesc.text = "Я оказался прав — здесь есть люди. Надеюсь, они смогут мне помочь. Я вижу несколько батыров, нужно с ними поговорить.";
                break;
            case 5:
                questName.text = "Задание - 5";
                questAim.text = "Цель - вернутся домой";
                questDesc.text = "Я безмерно рад — мне дали еду. С этими запасами мы, возможно, сможем выжить и добраться до большого города. Теперь осталось только вернуться к маме.";
                break;
            case 6:
                questName.text = "Задание - 6";
                questAim.text = "Цель - отдать еду маме";
                questDesc.text = "Я раздобыл еду. Осталось лишь отдать еду маме. Надеюсь она перестанет болеть.";
                break;
            case 7:
                questName.text = "Задание - 7";
                questAim.text = "Цель - поговорить с ханом";
                questDesc.text = "Мне кажется, я могу что-то изменить. Нужно поговорить с ханом и убедить его созвать Ханский совет. Это единственный способ сообщить всем о беде нашего народа.";
                break;
            default:
                questName.text = "Квест завершен!";
                questAim.text = "";
                questDesc.text = "Поздравляем, вы выполнили все задания!";


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
