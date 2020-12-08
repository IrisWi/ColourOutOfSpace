using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void GoToControlsMenu()
    {
        SceneManager.LoadScene("ControlsMenu", LoadSceneMode.Single);
    }

    public void GoToIntroduction()
    {
        SceneManager.LoadScene("Introduction", LoadSceneMode.Single);
    }

    public void GoToEndOne()
    {
        SceneManager.LoadScene("End1", LoadSceneMode.Single);
    }

    public void GoToEndTwo()
    {
        SceneManager.LoadScene("End2", LoadSceneMode.Single);
    }
    public void GoToEndThree()
    {
        SceneManager.LoadScene("End3", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
