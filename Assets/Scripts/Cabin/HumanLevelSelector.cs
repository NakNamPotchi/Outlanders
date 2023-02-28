using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HumanLevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    void Start()
    {
        int HumanLevelSelector = PlayerPrefs.GetInt("HumanLevelSelector", 0);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > HumanLevelSelector)
                levelButtons[i].interactable = false;
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
