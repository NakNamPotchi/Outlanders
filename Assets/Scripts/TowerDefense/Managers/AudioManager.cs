using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public enum Sound
    {
        Pinya,
        Suklay,
        Unggoy,
        Kandila,
        Durian,
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public Sound sound;
        public AudioClip audioClip;
    }

    public SoundAudioClip[] SFXlibrary;

    public void PlayerSound(Sound SFX)
    {
        GameObject soundGO = new GameObject("Sound");
        AudioSource audioSource = soundGO.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(SFX));
        Destroy(soundGO, 1f);

    }

    private AudioClip GetAudioClip(Sound sound)
    {
        foreach (var item in SFXlibrary)
        {
            if(item.sound == sound)
            {
                return item.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;

    }


}
