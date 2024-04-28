using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;  // Reference to the slider

    private void Start()
    {
        LoadVolume();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        SaveVolume(volume);
    }

    private void SaveVolume(float volume)
    {
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    private void LoadVolume()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MasterVolume");
            audioMixer.SetFloat("volume", savedVolume);
            volumeSlider.value = savedVolume;  // Update the slider's value
        }
    }
}
