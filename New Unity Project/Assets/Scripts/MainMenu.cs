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
        SceneManager.LoadScene("MainCredits");
    }

    public void PlayLevel03 ()
    {
        SceneManager.LoadScene("Level03");
    }
}
