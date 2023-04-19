using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkipSceneManager : MonoBehaviour
{
    public SceneFader fader;
    [SerializeField] private Button skipButton;
    [SerializeField] private TextMeshProUGUI skipText;
    private float fadeDuration = 1f;

    public void Start()
    {
        StartCoroutine(StartTextFadeIn(3f));
    }

    IEnumerator StartTextFadeIn(float time)
    {
        yield return new WaitForSeconds(time);
        
        skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, alpha);
            yield return null;
        }

        skipButton.interactable = true;
    }

    public void SkipScene(string sceneToLoad)
    {
        if (SceneManager.GetActiveScene().name == "IntroductionToresmundo")
        {
            string NextScene = "Stage0";
            int SkipTutorialStage = PlayerPrefs.GetInt("SkipTutorialStage");
            if (SkipTutorialStage > 0)
            {
                fader.FadeTo(sceneToLoad);
            }
            else    
            {
                fader.FadeTo(NextScene);
            }
            }
        else
        {
            fader.FadeTo(sceneToLoad);
        }
    }
}
