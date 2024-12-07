using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pen : MonoBehaviour
{
    private int sheepCount;
    public DialogLogic dialog;


    public void UpdateSheepCount()
    {
        sheepCount++;
        CheckCount();
    }

    private void CheckCount()
    {
        if (sheepCount >= 5)
        {
            dialog.WinMiniGame();
        }

    }


}
