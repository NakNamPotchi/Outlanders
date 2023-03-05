using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    public SceneFader fader;
    [SerializeField] public string NextScene;
    public int StoryToSkip;

    void OnEnable() {
        PlayerPrefs.SetInt("SkipStoryUnlocked", StoryToSkip);
        fader.FadeTo(NextScene);
    }
}