using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StorySelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] storyButtons;

    private int storyReached;

    void Start()
    {
        int storyReached = PlayerPrefs.GetInt("storyReached");

        for (int i = 0; i < storyButtons.Length; i++)
        {
            if (i + 1 > storyReached)
                storyButtons[i].interactable = false;
        }
    }

    public void Select (string storyScene)
    {
        fader.FadeTo(storyScene);
    }
}
