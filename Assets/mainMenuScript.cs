using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
   // Code from Brackeys
   public void PlayGame ()
    {
    SceneManager.LoadScene("lv1-jacob");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
