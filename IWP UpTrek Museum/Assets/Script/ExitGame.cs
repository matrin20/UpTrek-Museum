using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    private bool isQuitting = false;

    private void Update()
    {
        if (isQuitting)
        {
            Application.Quit();
        }
    }
    public void StopGame()
    {
        isQuitting = true;
    }


}
