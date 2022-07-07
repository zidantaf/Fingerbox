using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitGame ()
    {
        Debug.Log("Fingerbox Closed.");
        Application.Quit();

    }

    public void Credits()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainCredits");
    }

    public void MainMenus()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayLevel03 ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level03");
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
