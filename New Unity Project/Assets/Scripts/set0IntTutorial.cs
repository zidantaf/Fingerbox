using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class set0IntTutorial : MonoBehaviour
{

    private static readonly string OpenTutorial = "OpenTutorial";
    public void OpenTutor()
    {
        PlayerPrefs.SetInt(OpenTutorial, 0);
    }

    public void OpenTutorial2()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
