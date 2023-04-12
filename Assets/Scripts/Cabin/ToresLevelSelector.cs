using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToresLevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;
    public Image[] levelImages;
    public TextMeshProUGUI[] levelTexts;
    [SerializeField] private Sprite[] unlockedToresIcons;

    private int MooltosBookSelector;

    void Start()
    {
        int MooltosBookSelector = PlayerPrefs.GetInt("MooltosBookSelector");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > MooltosBookSelector)
            {
                levelButtons[i].interactable = false;
                levelTexts[i].text = "?";
            }
            else
            {
                levelButtons[i].interactable = true;
                levelImages[i].sprite = unlockedToresIcons[i];
            }
        }
    }

    public void Select (string levelName)
    {
        fader.FadeTo(levelName);
    }
}
