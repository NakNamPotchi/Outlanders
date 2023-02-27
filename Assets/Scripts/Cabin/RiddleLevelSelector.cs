using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RiddleLevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    void Start()
    {
        int RiddleLevelSelector = PlayerPrefs.GetInt("RiddleLevelSelector", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > RiddleLevelSelector)
                levelButtons[i].interactable = false;
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
