using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StorySelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] storyButtons;

    void Start()
    {
        int StorySelector = PlayerPrefs.GetInt("StorySelector", 0);

        for (int i = 0; i < storyButtons.Length; i++)
        {
            if (i + 1 > StorySelector)
                storyButtons[i].interactable = false;
        }
    }

    public void Select (string storyScene)
    {
        fader.FadeTo(storyScene);
    }
}
