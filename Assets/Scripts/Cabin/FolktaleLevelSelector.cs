using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FolktaleLevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    private int FolktaleBookSelector;

    void Start()
    {
        int FolktaleBookSelector = PlayerPrefs.GetInt("FolktaleBookSelector");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > FolktaleBookSelector)
                levelButtons[i].interactable = false;
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
