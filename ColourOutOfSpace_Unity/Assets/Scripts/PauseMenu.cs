using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI; 

    [SerializeField] private bool isPaused;


    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActiveMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    void ActiveMenu()
    {
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        //Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }
}
