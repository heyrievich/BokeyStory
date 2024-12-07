using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Restart", 55f);
    }

    private void Restart()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
