using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int rollMenu;
    public int tutorial;

    public void PlayGame()
    {
        SceneManager.LoadScene(rollMenu);
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(tutorial);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
