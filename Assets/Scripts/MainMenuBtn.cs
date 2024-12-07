using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Импортируем пространство имен для работы с сценами

public class MainMenuBtn : MonoBehaviour
{
    public Animator animator;
    public DictorSoundController dictorController;

    public AudioSource source;
    public AudioClip SFX;

    public void Exit()
    {
        source.PlayOneShot(SFX);
        Application.Quit();
    }

    public void Play()
    {
        animator.Play("SecondGameJam");
        dictorController.SecondSound();
        source.PlayOneShot(SFX);
        // Используем Invoke для вызова метода LoadGameScene через 22.5 секунды
        Invoke("LoadGameScene", 22.5f);
    }

    // Метод для перехода на сцену Game Play
    private void LoadGameScene()
    {
        // Загружаем сцену с именем "GamePlay"
        SceneManager.LoadScene("Game Play");
    }
}
