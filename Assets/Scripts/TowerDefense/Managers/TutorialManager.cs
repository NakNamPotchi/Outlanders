using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject nextButtonPanel;

    [Header("Images")]
    [SerializeField] private Image blackImage;

    [Header("Button")]
    [SerializeField] private Button welcomeNext;

    private float fadeDuration = 1f;
    private float startingAlpha;

    private void Start()
    {
        StartCoroutine(ExecuteNextEnable(5f));
    }

    IEnumerator ExecuteNextEnable(float time)
    {
        yield return new WaitForSeconds(time);

        float timeElapsed = 0;
        Color buttonColor = welcomeNext.image.color;
        nextButtonPanel.SetActive(true);

        while (timeElapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            buttonColor.a = alpha;
            welcomeNext.image.color = buttonColor;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        PauseTime();
        buttonColor.a = 1;
        welcomeNext.image.color = buttonColor;
        
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    public void PauseTime()
    {
        Time.timeScale = 0f;
    }
}
