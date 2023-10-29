using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControlling : MonoBehaviour
{
    public Slider volumeSlider;
    public Text volumeText;

    private void Start()
    {
        float initialVolume = PlayerPrefs.GetFloat("Volume", 1.0f);
        SetVolume(initialVolume);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeText.text = (volume * 100).ToString("F0") + "%";

        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}