using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToresmundoSkipStory : MonoBehaviour
{
    public SceneFader fader;

    public Button skipButton;

    private int SkipTutorialScene;

    void Start()
    {
        int SkipTutorialScene = PlayerPrefs.GetInt("SkipTutorialScene");

        if (SkipTutorialScene > 0)
            skipButton.interactable = true;
        else
            skipButton.interactable = false;
    }

    public void Select (string storyScene)
    {
        fader.FadeTo(storyScene);
    }
}
