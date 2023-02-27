using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FolktaleLevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    void Start()
    {
        int FolktaleLevelSelector = PlayerPrefs.GetInt("FolktaleLevelSelector", 0);

        for (int i = -1; i < levelButtons.Length; i++)
        {
            if (i + 1 > FolktaleLevelSelector)
                levelButtons[i].interactable = false;
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
