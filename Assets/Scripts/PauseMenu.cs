using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Animator animator;
    public AudioSource source;
    public AudioClip SFX;
    public AudioClip swoosh;


    public void PauseGame()
    {
        animator.Play("OpenPause");
        Invoke("StopTime", 1);
    }

    public void ContGame()
    {
        Time.timeScale = 1f;
        animator.Play("ClosePause");
        source.PlayOneShot(SFX);
        source.PlayOneShot(swoosh);
    }

    private void StopTime()
    {
        Time.timeScale = 0f;
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        source.PlayOneShot(SFX);

    }
}
