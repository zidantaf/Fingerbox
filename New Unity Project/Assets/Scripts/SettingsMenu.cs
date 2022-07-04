using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public AudioMixerGroup master;
    public AudioMixerGroup music;
    public AudioMixerGroup sefex;

    public void SetVolume (float volume)
    {
        master.audioMixer.SetFloat("MasterX", volume);
    }

    public void SetVolumeMusic (float volume)
    {
        music.audioMixer.SetFloat("MusicX", volume);
    }
    public void SetVolumeSFX (float volume)
    {
        sefex.audioMixer.SetFloat("EffectX", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("_qualityIndex", qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


}
