using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoaderIntroductionOnly : MonoBehaviour
{
    public SceneFader fader;

    private int SkipTutorialStage;

    [SerializeField] public string NextScene;
    [SerializeField] public string SkipToScene;

    public void OnEnable() {
        SkipTutorialStage = PlayerPrefs.GetInt("SkipTutorialStage");

        if (SkipTutorialStage > 0)
        {
            fader.FadeTo(SkipToScene);
        }
        else    
        {
            fader.FadeTo(NextScene);
        }
    }
}