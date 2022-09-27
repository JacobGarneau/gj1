using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("title");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
