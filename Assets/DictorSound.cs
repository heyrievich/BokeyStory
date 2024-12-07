using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictorSound : MonoBehaviour
{
    public AudioSource source;

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;
    public AudioClip clip4;
    // Start is called before the first frame update
    void Start()
    {
        source.PlayOneShot(clip1);
        Invoke("clipStop", 10.2f);
        Invoke("clip1Play", 13.5f);
        Invoke("clip2Play", 27f);
        Invoke("clip3Play", 37.5f);
    }

    private void clip1Play()
    {
        source.PlayOneShot(clip2);
    }
    private void clip2Play()
    {
        source.PlayOneShot(clip3);
    }
    private void clip3Play()
    {
        source.PlayOneShot(clip4);
    }

    private void clipStop()
    {
        source.Stop();
    }

}
