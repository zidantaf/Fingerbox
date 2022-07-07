using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    public Slider masterslider;
    public Slider musicslider;
    public Slider sfxslider;
    public Dropdown qualitygraphic;

    public Text masterValueText;


    void Start()
    {
        float masterValue = masterslider.value;
        masterslider.value = PlayerPrefs.GetFloat("MasterX");

        float musicValue = musicslider.value;
        musicslider.value = PlayerPrefs.GetFloat("MusicX");

        float sfxValue = sfxslider.value;
        sfxslider.value = PlayerPrefs.GetFloat("EffectX");

        qualitygraphic.value = PlayerPrefs.GetInt("_qualityindex");

    }

    public void Update()
    {
        masterValueText.text = PlayerPrefs.GetFloat("MasterX").ToString("0");
    }
}
