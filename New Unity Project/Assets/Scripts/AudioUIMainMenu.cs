using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioUIMainMenu : MonoBehaviour
{
    public AudioClip click01;
    public AudioClip click02;
    public AudioClip clickCredits;
    public AudioSource audioSource;
 
    public static AudioUIMainMenu instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickMenu1()
    {
        audioSource.PlayOneShot(click01, 1f);
    }
    public void ClickMenu2()
    {
        audioSource.PlayOneShot(click02, 1f);
    }
    public void ClickCredits()
    {
        audioSource.PlayOneShot(clickCredits, 0.1f);
    }
}
