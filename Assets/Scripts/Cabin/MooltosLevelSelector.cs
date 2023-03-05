using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MooltosLevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    private int MooltosBookSelector;

    void Start()
    {
        int MooltosBookSelector = PlayerPrefs.GetInt("MooltosBookSelector");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > MooltosBookSelector)
                levelButtons[i].interactable = false;
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
