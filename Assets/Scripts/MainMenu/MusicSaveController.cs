using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MusicSaveController : MonoBehaviour
{
    [SerializeField] private Slider musicSlider = null;
    [SerializeField] private TextMeshProUGUI musicTextUI = null;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("VolumeValue"))
        {
            PlayerPrefs.SetFloat("VolumeValue", (int)(1 * 100));
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
