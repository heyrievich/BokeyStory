using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictorSoundController : MonoBehaviour
{
    private AudioSource source;
    public AudioClip firstSound;
    public AudioClip secondSound;
    public AudioClip secondSoundCont;
    public AudioClip thirdSound;


    void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(firstSound);
    }

    public void SecondSound()
    {
        source.PlayOneShot(secondSound);
        Invoke("ContinueSecondSound", 3.9f);
        Invoke("ThirdSoundPlay", 11.5f);
    }

    public void ContinueSecondSound()
    {
        source.PlayOneShot(secondSoundCont);
    }
	

    public void ThirdSoundPlay()
    {
        source.PlayOneShot(thirdSound);
    }
}
