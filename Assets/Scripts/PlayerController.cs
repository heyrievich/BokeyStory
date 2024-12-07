using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения
    public float rotationSpeed = 5f; // Скорость поворота
    public Animator animator; // Ссылка на аниматор
    private Vector3 targetPosition;
    private bool isMoving = false;
    public string currentTriggerTag = ""; // Хранит текущий тег триггера
    public LayerMask terrainLayer; // Слой для проверки террейна
    public SecondQuest secondQuest;
    public DialogLogic dialog;
    public DialogWithMom dialogWithMom;
    public DialogWithHan dialogWithKhan;

    public QuestSystem questSys;
    public bool canWalk = true;

    public AudioSource source;
    public AudioSource source2;

    public AudioClip stepGrass; // Звук шагов на траве
    public AudioClip take;
    public AudioClip note;

    private void Update()
    {
        if (canWalk)
        {
            // Движение персонажа
            if (Input.GetMouseButtonDown(0)) // Левая кнопка мыши
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, terrainLayer))
                {
                    targetPosition = hit.point;
                    isMoving = true;

                    // Воспроизведение звука шагов
                    if (!source.isPlaying)
                    {
                        source.clip = stepGrass;
                        source.loop = true; // Включаем зацикливание
                        source.Play();
                    }
                }
            }
        }

        if (isMoving)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Плавный поворот в сторону движения
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            // Переключение анимации
            animator.SetBool("isRun", true);

            // Остановка при достижении точки
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                animator.SetBool("isRun", false);

                // Остановка звука шагов
                if (source.isPlaying && source.clip == stepGrass)
                {
                    source.Stop();
                    source.loop = false; // Отключаем зацикливание
                }
            }
        }

        // Взаимодействие с объектами
        if (Input.GetKeyDown(KeyCode.E) && currentTriggerTag != "")
        {
            switch (currentTriggerTag)
            {
                case "artefact1":
                    InteractWithArtefact1();
                    break;
                case "artefact2":
                    InteractWithArtefact2();
                    break;
                case "artefact3":
                    InteractWithArtefact3();
                    break;
                case "artefact4":
                    InteractWithArtefact4();
                    break;
                case "Kost":
                    InteractWithKost();
                    break;
                case "DialogWithMom":
                    if (questSys.quest == 6)
                    {
                        StartDialogWithMom();
                    }
                    break;

                case "DialogWithKhan":
                    if (questSys.quest == 7)
                    {
                        StartDialogWithKhan();
                    }
                    break;

                case "Dialog":
                    if (questSys.quest == 4)
                    {
                        StartDialog();
                    }
                    break;
            }
        }
    }

    private void FixedUpdate()
    {
        // Гарантируем, что персонаж стоит на ногах
        Vector3 fixedPosition = transform.position;
        fixedPosition.y = Mathf.Max(fixedPosition.y, Terrain.activeTerrain.SampleHeight(transform.position));
        transform.position = fixedPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentTriggerTag = other.tag;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == currentTriggerTag)
        {
            currentTriggerTag = "";
        }
    }

    private void InteractWithArtefact1()
    {
        secondQuest.Artefact1Found();
        source2.PlayOneShot(take);
    }

    private void InteractWithArtefact2()
    {
        secondQuest.Artefact2Found();
        source2.PlayOneShot(take);
    }

    private void InteractWithArtefact3()
    {
        secondQuest.Artefact3Found();
        source2.PlayOneShot(take);
    }

    private void InteractWithArtefact4()
    {
        secondQuest.Artefact4Found();
        source2.PlayOneShot(take);
    }

    private void StartDialog()
    {
        dialog.OpenDialog();
        dialog.isClickable = true;
        source2.PlayOneShot(note);
    }

    private void StartDialogWithMom()
    {
        dialogWithMom.OpenDialog();
        dialogWithMom.isClickable = true;
        source2.PlayOneShot(note);
    }

    private void InteractWithKost()
    {
        secondQuest.KostFound();
        source2.PlayOneShot(note);
    }

    private void StartDialogWithKhan()
    {
        dialogWithKhan.OpenDialog();
        dialogWithKhan.isClickable = true;
        source2.PlayOneShot(note);
    }
}