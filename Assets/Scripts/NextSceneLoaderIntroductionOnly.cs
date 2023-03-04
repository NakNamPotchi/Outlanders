using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoaderIntroductionOnly : MonoBehaviour
{
    public SceneFader fader;

    public int SkipTutorialStage;

    [SerializeField] public string NextScene;
    [SerializeField] public string SkiptoScene;

    void OnEnable() {
        SkipTutorialStage = PlayerPrefs.GetInt("SkipTutorialStage");

        if (SkipTutorialStage > 0)
        {
            fader.FadeTo(SkiptoScene);
        }
        else    
        {
            fader.FadeTo(NextScene);
        }
    }
}