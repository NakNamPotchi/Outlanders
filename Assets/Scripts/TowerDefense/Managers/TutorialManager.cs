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
    [SerializeField] private GameObject countdownPanel;
    [SerializeField] private GameObject countdownNextButtonPanel;
    [SerializeField] private GameObject waveArrowPanel;
    [SerializeField] private GameObject waveArrowNextButtonPanel;

    [Header("Button")]
    [SerializeField] private Button welcomeNext;
    [SerializeField] private Button countdownNext;
    [SerializeField] private Button waveArrowNext;

    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI countdownMainText;
    [SerializeField] private TextMeshProUGUI countdownSubText;
    [SerializeField] private TextMeshProUGUI waveArrowMainText;
    [SerializeField] private TextMeshProUGUI waveArrowSubText;

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
        
        welcomeNext.interactable = true;
        PauseTime();
        buttonColor.a = 1;
        welcomeNext.image.color = buttonColor;
    }

    public void StartCountdownTutorial()
    {
        StartCoroutine(ExecuteCountdownEnable(0.5f));
    }

    IEnumerator ExecuteCountdownEnable(float time)
    {
        yield return new WaitForSeconds(time);
        
        countdownMainText.color = new Color(countdownMainText.color.r, countdownMainText.color.g, countdownMainText.color.b, 0);
        countdownSubText.color = new Color(countdownSubText.color.r, countdownSubText.color.g, countdownSubText.color.b, 0);
        float timeElapsed = 0;
        countdownPanel.SetActive(true);

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            countdownMainText.color = new Color(countdownMainText.color.r, countdownMainText.color.g, countdownMainText.color.b, alpha);
            countdownSubText.color = new Color(countdownSubText.color.r, countdownSubText.color.g, countdownSubText.color.b, alpha);
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

        countdownNext.interactable = true;
        PauseTime();
        buttonColor.a = 1;
        countdownNext.image.color = buttonColor;
    }

    public void StartWaveArrowTutorial()
    {
        StartCoroutine(ExecuteWaveArrowEnable(0.5f));
    }

    IEnumerator ExecuteWaveArrowEnable(float time)
    {
        yield return new WaitForSeconds(time);
        
        waveArrowMainText.color = new Color(waveArrowMainText.color.r, waveArrowMainText.color.g, waveArrowMainText.color.b, 0);
        waveArrowSubText.color = new Color(waveArrowSubText.color.r, waveArrowSubText.color.g, waveArrowSubText.color.b, 0);
        float timeElapsed = 0;
        waveArrowPanel.SetActive(true);

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            waveArrowMainText.color = new Color(waveArrowMainText.color.r, waveArrowMainText.color.g, waveArrowMainText.color.b, alpha);
            waveArrowSubText.color = new Color(waveArrowSubText.color.r, waveArrowSubText.color.g, waveArrowSubText.color.b, alpha);
            yield return null;
        }

        StartCoroutine(ExecuteWaveArrowNextEnable(3f));
    }

    IEnumerator ExecuteWaveArrowNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        waveArrowNextButtonPanel.SetActive(true);
        float timeElapsed = 0;
        Color buttonColor = waveArrowNext.image.color;

        while (timeElapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            buttonColor.a = alpha;
            waveArrowNext.image.color = buttonColor;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        waveArrowNext.interactable = true;
        PauseTime();
        buttonColor.a = 1;
        waveArrowNext.image.color = buttonColor;
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
