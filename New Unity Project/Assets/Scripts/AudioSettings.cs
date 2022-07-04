using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider masterslider;
    [SerializeField] private Slider musicslider;
    [SerializeField] private Slider sfxslider;
    [SerializeField] private Dropdown qualitygraphic;
    public void Start ()
    {
        LoadValues();
    }

    public void SaveVolumeButton()
    {
        float masterValue = masterslider.value;
        PlayerPrefs.SetFloat("MasterX", masterValue);

        float musicValue = musicslider.value;
        PlayerPrefs.SetFloat("MusicX", musicValue);

        float sfxValue = sfxslider.value;
        PlayerPrefs.SetFloat("EffectX", sfxValue);

        int qualityIndex = qualitygraphic.value;
        PlayerPrefs.SetInt("_qualityindex", qualityIndex);

        LoadValues();
    }

    public void LoadValues()
    {
        float masterValue = PlayerPrefs.GetFloat("MasterX");
        masterslider.value = masterValue;

        float musicValue = PlayerPrefs.GetFloat("MusicX");
        musicslider.value = musicValue;

        float sfxValue = PlayerPrefs.GetFloat("EffectX");
        sfxslider.value = sfxValue;

        qualitygraphic.value = PlayerPrefs.GetInt("_qualityIndex");

    }
}
