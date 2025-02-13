using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicSaveController : MonoBehaviour
{
    [SerializeField] private Slider musicSlider = null;
    [SerializeField] private TextMeshProUGUI musicTextUI = null;
    [SerializeField] private Slider soundSlider = null;
    [SerializeField] private TextMeshProUGUI soundTextUI = null;
    public AudioSource musicSource, sfxSource;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("MusicVolumeValue"))
        {
            PlayerPrefs.SetFloat("MusicVolumeValue", (int)(1));
            PlayerPrefs.SetFloat("SoundVolumeValue", (int)(1));
            LoadValues();
        }
        else
        {
            LoadValues();
        }
    }

    public void MusicSlider(float music)
    {
        musicTextUI.text = ((int)(music * 100)).ToString();
        AudioManager.Instance.MusicVolume(musicSlider.value);
    }

    public void SoundSlider(float sound)
    {
        soundTextUI.text = ((int)(sound * 100)).ToString();
        AudioManager.Instance.SFXVolume(soundSlider.value);
    }

    public void SaveMusicButton()
    {
        float musicValue = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolumeValue", musicValue);
        LoadValues();
    }

    public void SaveSoundButton()
    {
        float soundValue = soundSlider.value;
        PlayerPrefs.SetFloat("SoundVolumeValue", soundValue);
        LoadValues();
    }

    void LoadValues()
    {
        float musicVolumeValue = PlayerPrefs.GetFloat("MusicVolumeValue");
        float soundVolumeValue = PlayerPrefs.GetFloat("SoundVolumeValue");
        musicSlider.value = musicVolumeValue;
        AudioManager.Instance.MusicVolume(musicVolumeValue);
        AudioManager.Instance.SFXVolume(soundVolumeValue);
        soundSlider.value = soundVolumeValue;
    }
}
