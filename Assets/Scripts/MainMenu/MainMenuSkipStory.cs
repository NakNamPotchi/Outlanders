using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuSkipStory : MonoBehaviour
{
    public SceneFader fader;

    public Button[] stageButtons;

    private int SkipIntroductionStory;

    [SerializeField] public string SkipStory;

    void Start()
    {
        SkipIntroductionStory = PlayerPrefs.GetInt("SkipIntroductionStory");
    }

    public void Select (string stageName)
    {
        if (SkipIntroductionStory > 0)
        {
            fader.FadeTo(SkipStory);
        }
        else
        {
            fader.FadeTo(stageName);
        }
    }
}
