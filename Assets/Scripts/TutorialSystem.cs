using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSystem : MonoBehaviour
{
    public Animator tutorAnimator; // Аниматор для анимаций открытия/закрытия
    public GameObject tutor1;
    public GameObject tutor2;
    public GameObject wayPoint;
    private int clickCount;
    private bool isOpen;

    void Start()
    {
        tutorAnimator.Play("CloudAppear");
        tutor1.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Левая кнопка мыши
        {
            clickCount++;
        }

        if (clickCount == 3)
        {
            if(!isOpen)
            {
                isOpen = true;
                tutorAnimator.Play("CloudDisappear");
                Invoke("Tutor2Open", 1.5f);
            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            tutorAnimator.Play("CloudDisappear");
            wayPoint.SetActive(true);   
            Invoke("DestroyGM", 1.5f);
        }
    }

    public void Tutor2Open()
    {
        tutorAnimator.Play("CloudAppear");
        tutor1.SetActive(false);
        tutor2.SetActive(true);
    }

    public void DestroyGM()
    {
        Destroy(gameObject);
    }


}
