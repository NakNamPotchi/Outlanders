using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HumanLevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    private int HumanBookSelector;

    void Start()
    {
        int HumanBookSelector = PlayerPrefs.GetInt("HumanBookSelector");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > HumanBookSelector)
                levelButtons[i].interactable = false;
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
