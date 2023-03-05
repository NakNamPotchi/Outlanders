using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipStoryScript : MonoBehaviour
{
    public SceneFader fader;
    [SerializeField] public string NextScene;

    public Button skipButton;

    public int StoryToSkip;
    private int SkipStoryUnlocked; 

    void Start()
    {
        int SkipStoryUnlocked = PlayerPrefs.GetInt("SkipStoryUnlocked");

        if (SkipStoryUnlocked >= StoryToSkip)
            skipButton.interactable = true;
        else
            skipButton.interactable = false;
    }

    public void Select (string storyScene)
    {
        fader.FadeTo(storyScene);
    }
}
