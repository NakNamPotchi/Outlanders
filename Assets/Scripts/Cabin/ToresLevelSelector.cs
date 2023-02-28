using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToresLevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    void Start()
    {
        int ToresLevelSelector = PlayerPrefs.GetInt("ToresLevelSelector", 0);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > ToresLevelSelector)
                levelButtons[i].interactable = false;
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
