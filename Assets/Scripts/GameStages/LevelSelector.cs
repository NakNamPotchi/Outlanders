using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] stageButtons;

    private int stageReached;

    void Start()
    {
        int stageReached = PlayerPrefs.GetInt("stageReached");

        for (int i = 0; i < stageButtons.Length; i++)
        {
            if (i + 1 > stageReached)
                stageButtons[i].interactable = false;
        }
    }

    public void Select (string stageName)
    {
        fader.FadeTo(stageName);
    }
}
