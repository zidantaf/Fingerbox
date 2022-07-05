using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("Level03"); // Nanti diisi Scene Level
    }

    public void QuitGame ()
    {
        Debug.Log("Fingerbox Closed.");
        Application.Quit();

    }

    public void Credits()
    {
        SceneManager.LoadScene("MainCredits");
    }
}
