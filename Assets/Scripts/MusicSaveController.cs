using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSaveController : MonoBehaviour
{
    [SerializeField] private Slider musicSlider = null;

    [SerializeField] private Text musicTextUI = null;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("VolumeValue"))
        {
            PlayerPrefs.SetFloat("VolumeValue", 1);
            LoadValues();
        }
        else
        {
            LoadValues();
        }
    }

    public void MusicSlider(float music)
    {
        musicTextUI.text = music.ToString("0.0");
    }

    public void SaveMusicButton()
    {
        float musicValue = musicSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", musicValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("VolumeValue");
        musicSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
