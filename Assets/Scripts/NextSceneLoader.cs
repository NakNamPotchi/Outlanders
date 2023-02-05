using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    void OnEnable() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}