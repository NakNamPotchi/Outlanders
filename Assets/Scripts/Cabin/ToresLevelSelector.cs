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
    [SerializeField] private GameObject[] unlockWhen;
    [SerializeField] private GameObject toresSection;
    [SerializeField] private GameObject unlockedToresSection;
    [SerializeField] private GameObject[] unlockedTores;

    private int ToresBookSelector;

    void Start()
    {
        int ToresBookSelector = PlayerPrefs.GetInt("ToresBookSelector");

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > ToresBookSelector)
            {
                levelTexts[i].text = "?";
            }
            else
            {
                levelButtons[i].interactable = true;
                levelImages[i].sprite = unlockedToresIcons[i];
            }
        }
    }

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

    public void ClickTores(string towerText)
    {
        int ToresBookSelector = PlayerPrefs.GetInt("ToresBookSelector");

        if (towerText == "Suklay" && ToresBookSelector < 2)
        {
            unlockWhen[0].SetActive(true);
        }
        else if (towerText == "Suklay" && ToresBookSelector >= 2)
        {
            toresSection.SetActive(false);
            unlockedToresSection.SetActive(true);
            unlockedTores[0].SetActive(true);
        }
        else if (towerText == "Pagong" && ToresBookSelector < 3)
        {
            unlockWhen[1].SetActive(true);
        }
        else if (towerText == "Pagong" && ToresBookSelector >= 3)
        {
            toresSection.SetActive(false);
            unlockedToresSection.SetActive(true);
            unlockedTores[1].SetActive(true);
        }
        else if (towerText == "Kandila" && ToresBookSelector < 4)
        {
            unlockWhen[2].SetActive(true);
        }
        else if (towerText == "Kandila" && ToresBookSelector >= 4)
        {
            toresSection.SetActive(false);
            unlockedToresSection.SetActive(true);
            unlockedTores[2].SetActive(true);
        }
        else if (towerText == "Durian" && ToresBookSelector < 5)
        {
            unlockWhen[3].SetActive(true);
        }
        else if (towerText == "Durian" && ToresBookSelector >= 5)
        {
            toresSection.SetActive(false);
            unlockedToresSection.SetActive(true);
            unlockedTores[3].SetActive(true);
        }
    }
}
