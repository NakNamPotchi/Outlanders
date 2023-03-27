using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject nextButtonPanel;
    [SerializeField] private GameObject canvasBlackBackground;
    [SerializeField] private GameObject enemyPanel;
    [SerializeField] private GameObject countdownNextButtonPanel;
    [SerializeField] private GameObject waveArrowPanel;
    [SerializeField] private GameObject waveArrowNextButtonPanel;

    [Header("Button")]
    [SerializeField] private Button welcomeNext;
    [SerializeField] private Button countdownNext;
    [SerializeField] private Button enemyNext;

    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI countdownMainText;
    [SerializeField] private TextMeshProUGUI countdownSubText;
    [SerializeField] private TextMeshProUGUI enemyMainText;
    [SerializeField] private TextMeshProUGUI enemySubText;

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

    public void StartCountdownEnemyTutorial()
    {
        StartCoroutine(ExecuteCountdownEnemyEnable(1f));
    }

    IEnumerator ExecuteCountdownEnemyEnable(float time)
    {
        yield return new WaitForSeconds(time);
        
        countdownMainText.color = new Color(countdownMainText.color.r, countdownMainText.color.g, countdownMainText.color.b, 0);;
        countdownSubText.color = new Color(countdownSubText.color.r, countdownSubText.color.g, countdownSubText.color.b, 0);;
        float timeElapsed = 0;
        enemyPanel.SetActive(true);

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            countdownMainText.color = new Color(countdownMainText.color.r, countdownMainText.color.g, countdownMainText.color.b, alpha);
            countdownSubText.color = new Color(countdownSubText.color.r, countdownSubText.color.g, countdownSubText.color.b, alpha);;
            yield return null;
        }

        StartCoroutine(ExecuteCountdownNextEnable(3f));
    }

    IEnumerator ExecuteCountdownNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        countdownNextButtonPanel.SetActive(true);
        float timeElapsed = 0;
        Color buttonColor = countdownNext.image.color;

        while (timeElapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            buttonColor.a = alpha;
            countdownNext.image.color = buttonColor;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        PauseTime();
        buttonColor.a = 1;
        countdownNext.image.color = buttonColor;
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
