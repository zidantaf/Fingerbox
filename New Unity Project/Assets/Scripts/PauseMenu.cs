using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pausemenuUI;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }

        

    }
    public void Resume()
    {
        Debug.Log("Game continued.");
        GameIsPaused = false;
        Time.timeScale = 1f;
        pausemenuUI.SetActive(false);
    }

    public void Paused()
    {
        Debug.Log("Game is paused.");
        pausemenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

}
