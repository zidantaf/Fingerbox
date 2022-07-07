using UnityEngine.UI;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public Slider masterslider;
    public Slider musicslider;
    public Slider sfxslider;
    public Dropdown qualitygraphic;

    public Text masterValueText;

    private static readonly string FirstPlay = "FirstPlay";
    private int firstPlayInt;
    private float sfxsliderFirstFloat = 11.5f;


    public void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt("FirstPlay");


        masterslider.value = PlayerPrefs.GetFloat("MasterX");

        musicslider.value = PlayerPrefs.GetFloat("MusicX");

        sfxslider.value = PlayerPrefs.GetFloat("EffectX");

        qualitygraphic.value = PlayerPrefs.GetInt("_qualityindex");

        if (firstPlayInt == 0)
        {
            PlayerPrefs.SetFloat("EffectX", sfxsliderFirstFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }

    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteAll();

        masterslider.value = PlayerPrefs.GetFloat("MasterX");

        musicslider.value = PlayerPrefs.GetFloat("MusicX");

        sfxslider.value = 11.5f;

        qualitygraphic.value = PlayerPrefs.GetInt("_qualityindex");
    }
}
