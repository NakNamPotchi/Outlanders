using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LegendLevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;
    public TextMeshProUGUI[] levelTexts;

    private int LegendBookSelector;

    void Start()
    {
        int LegendBookSelector = PlayerPrefs.GetInt("LegendBookSelector");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > LegendBookSelector)
            {
                levelTexts[i].text = "?";
                levelButtons[i].interactable = false;
            }
            else
            {
                levelButtons[i].interactable = true;
            }
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
