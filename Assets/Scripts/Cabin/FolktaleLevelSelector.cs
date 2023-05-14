using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FolktaleLevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;
    public Image[] levelImages;
    [SerializeField] private Sprite[] unlockedFolktalesIcons;

    private int FolktaleBookSelector;

    void Start()
    {
        int FolktaleBookSelector = PlayerPrefs.GetInt("FolktaleBookSelector");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > FolktaleBookSelector)
            {
                levelButtons[i].interactable = false;
            }
            else
            {
                levelButtons[i].interactable = true;
                levelImages[i].sprite = unlockedFolktalesIcons[i];
            }
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
