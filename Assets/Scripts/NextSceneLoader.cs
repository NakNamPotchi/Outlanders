using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    public SceneFader fader;
    [SerializeField] public string NextScene;

    void OnEnable() {
        fader.FadeTo(NextScene);
    }
}