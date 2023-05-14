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
    public Image[] levelImages;
    [SerializeField] private Sprite[] unlockedLegendsIcons;

    private int LegendBookSelector;

    void Start()
    {
        int LegendBookSelector = PlayerPrefs.GetInt("LegendBookSelector");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > LegendBookSelector)
            {
                levelButtons[i].interactable = false;
            }
            else
            {
                levelButtons[i].interactable = true;
                levelImages[i].sprite = unlockedLegendsIcons[i];
            }
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
