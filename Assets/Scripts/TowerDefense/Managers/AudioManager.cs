using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSound, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private bool musicPlaying = true;
    private int startingSceneIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
            startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        PlayMusic("Theme");
        if (SceneManager.GetActiveScene().name == "Cabin")
            PlayCabinSFX();
        if (SceneManager.GetActiveScene().name == "MainMenu")
            PlayMainMenuSFX();
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (SceneManager.GetActiveScene().buildIndex != startingSceneIndex)
        {
            Destroy(gameObject);
        }

        if (!musicPlaying)
        {
            musicSource.Stop();
        }
    }

    private void PlayCabinSFX()
    {
        PlaySound("Candle");
        PlaySound("Portal");
        PlaySound("Ambience");
    }

    private void PlayMainMenuSFX()
    {
        PlaySound("Bush");
        PlaySound("Fireflies");
        PlaySound("Ambience");
        PlaySound("Mystical");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
