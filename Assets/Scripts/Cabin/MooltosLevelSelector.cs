using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MooltosLevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    void Start()
    {
        int MooltosLevelSelector = PlayerPrefs.GetInt("MooltosLevelSelector", 0);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > MooltosLevelSelector)
                levelButtons[i].interactable = false;
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
