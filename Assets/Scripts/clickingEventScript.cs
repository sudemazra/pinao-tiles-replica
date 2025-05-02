using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickingEventScript : MonoBehaviour
{
    public void startButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void aboutUs()
    {
        SceneManager.LoadScene(4);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void aboutUsBack()
    {
        SceneManager.LoadScene(1);
    }

    
}
