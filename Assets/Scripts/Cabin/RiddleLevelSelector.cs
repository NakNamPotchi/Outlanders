using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RiddleLevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    private int RiddleBookSelector;

    void Start()
    {
        int RiddleBookSelector = PlayerPrefs.GetInt("RiddleBookSelector");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > RiddleBookSelector)
                levelButtons[i].interactable = false;
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
