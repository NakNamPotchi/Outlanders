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
    [SerializeField] private GameObject coinsHeartsPanel;
    [SerializeField] private GameObject coinsHeartsNextButtonPanel;
    [SerializeField] private GameObject wavePanel;
    [SerializeField] private GameObject waveNextButtonPanel;
    [SerializeField] private GameObject enemyPathPanel;
    [SerializeField] private GameObject enemyPathNextButtonPanel;
    [SerializeField] private GameObject mooltosPanel;
    [SerializeField] private GameObject mooltosNextButtonPanel;
    [SerializeField] private GameObject towerTilesPanel;
    [SerializeField] private GameObject towerTilesNextButtonPanel;

    [Header("Button")]
    [SerializeField] private Button welcomeNext;
    [SerializeField] private Button countdownNext;
    [SerializeField] private Button waveArrowNext;
    [SerializeField] private Button coinsHeartsNext;
    [SerializeField] private Button waveNext;    
    [SerializeField] private Button enemyPathNext;
    [SerializeField] private Button mooltosNext;
    [SerializeField] private Button towerTilesNext;
    [SerializeField] private Button settingsButton;

    [Header("Nodes")]
    [SerializeField] private Button[] node;

    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI countdownMainText;
    [SerializeField] private TextMeshProUGUI countdownSubText;
    [SerializeField] private TextMeshProUGUI waveArrowMainText;
    [SerializeField] private TextMeshProUGUI waveArrowSubText;
    [SerializeField] private TextMeshProUGUI coinsHeartsMainText;
    [SerializeField] private TextMeshProUGUI coinsHeartsSubText;
    [SerializeField] private TextMeshProUGUI waveMainText;
    [SerializeField] private TextMeshProUGUI waveSubText;
    [SerializeField] private TextMeshProUGUI enemyPathMainText;
    [SerializeField] private TextMeshProUGUI enemyPathSubText;
    [SerializeField] private TextMeshProUGUI mooltosMainText;
    [SerializeField] private TextMeshProUGUI mooltosSubText;
    [SerializeField] private TextMeshProUGUI towerTilesMainText;
    [SerializeField] private TextMeshProUGUI towerTilesSubText;

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
        StartCoroutine(ExecuteWaveArrowEnable(0.1f));
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

    public void StartCoinsHeartTutorial()
    {
        StartCoroutine(ExecuteCoinsHeartEnable(0.1f));
    }

    IEnumerator ExecuteCoinsHeartEnable(float time)
    {
        yield return new WaitForSeconds(time);
        
        coinsHeartsMainText.color = new Color(coinsHeartsMainText.color.r, coinsHeartsMainText.color.g, coinsHeartsMainText.color.b, 0);
        coinsHeartsSubText.color = new Color(coinsHeartsSubText.color.r, coinsHeartsSubText.color.g, coinsHeartsSubText.color.b, 0);
        float timeElapsed = 0;
        coinsHeartsPanel.SetActive(true);

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            coinsHeartsMainText.color = new Color(coinsHeartsMainText.color.r, coinsHeartsMainText.color.g, coinsHeartsMainText.color.b, alpha);
            coinsHeartsSubText.color = new Color(coinsHeartsSubText.color.r, coinsHeartsSubText.color.g, coinsHeartsSubText.color.b, alpha);
            yield return null;
        }

        StartCoroutine(ExecuteCoinsHeartNextEnable(3f));
    }

    IEnumerator ExecuteCoinsHeartNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        coinsHeartsNextButtonPanel.SetActive(true);
        float timeElapsed = 0;
        Color buttonColor = coinsHeartsNext.image.color;

        while (timeElapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            buttonColor.a = alpha;
            coinsHeartsNext.image.color = buttonColor;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        coinsHeartsNext.interactable = true;
        PauseTime();
        buttonColor.a = 1;
        coinsHeartsNext.image.color = buttonColor;
    }

    public void StartWaveTutorial()
    {
        StartCoroutine(ExecuteWaveEnable(0.1f));
    }

    IEnumerator ExecuteWaveEnable(float time)
    {
        yield return new WaitForSeconds(time);
        
        waveMainText.color = new Color(waveMainText.color.r, waveMainText.color.g, waveMainText.color.b, 0);
        waveSubText.color = new Color(waveSubText.color.r, waveSubText.color.g, waveSubText.color.b, 0);
        float timeElapsed = 0;
        wavePanel.SetActive(true);

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            waveMainText.color = new Color(waveMainText.color.r, waveMainText.color.g, waveMainText.color.b, alpha);
            waveSubText.color = new Color(waveSubText.color.r, waveSubText.color.g, waveSubText.color.b, alpha);
            yield return null;
        }

        StartCoroutine(ExecuteWaveNextEnable(3f));
    }

    IEnumerator ExecuteWaveNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        waveNextButtonPanel.SetActive(true);
        float timeElapsed = 0;
        Color buttonColor = waveNext.image.color;

        while (timeElapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            buttonColor.a = alpha;
            waveNext.image.color = buttonColor;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        waveNext.interactable = true;
        PauseTime();
        buttonColor.a = 1;
        waveNext.image.color = buttonColor;
    }

    public void StartEnemyPathTutorial()
    {
        StartCoroutine(ExecuteEnemyPathEnable(0.1f));
    }

    IEnumerator ExecuteEnemyPathEnable(float time)
    {
        yield return new WaitForSeconds(time);
        
        enemyPathMainText.color = new Color(enemyPathMainText.color.r, enemyPathMainText.color.g, enemyPathMainText.color.b, 0);
        enemyPathSubText.color = new Color(enemyPathSubText.color.r, enemyPathSubText.color.g, enemyPathSubText.color.b, 0);
        float timeElapsed = 0;
        enemyPathPanel.SetActive(true);

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            enemyPathMainText.color = new Color(enemyPathMainText.color.r, enemyPathMainText.color.g, enemyPathMainText.color.b, alpha);
            enemyPathSubText.color = new Color(enemyPathSubText.color.r, enemyPathSubText.color.g, enemyPathSubText.color.b, alpha);
            yield return null;
        }

        StartCoroutine(ExecuteEnemyPathNextEnable(3f));
    }

    IEnumerator ExecuteEnemyPathNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        enemyPathNextButtonPanel.SetActive(true);
        float timeElapsed = 0;
        Color buttonColor = enemyPathNext.image.color;

        while (timeElapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            buttonColor.a = alpha;
            enemyPathNext.image.color = buttonColor;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        enemyPathNext.interactable = true;
        PauseTime();
        buttonColor.a = 1;
        enemyPathNext.image.color = buttonColor;
    }

    public void StartMooltosTutorial()
    {
        StartCoroutine(ExecuteMooltosEnable(0.1f));
    }

    IEnumerator ExecuteMooltosEnable(float time)
    {
        yield return new WaitForSeconds(time);
        
        mooltosMainText.color = new Color(mooltosMainText.color.r, mooltosMainText.color.g, mooltosMainText.color.b, 0);
        mooltosSubText.color = new Color(mooltosSubText.color.r, mooltosSubText.color.g, mooltosSubText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            mooltosMainText.color = new Color(mooltosMainText.color.r, mooltosMainText.color.g, mooltosMainText.color.b, alpha);
            mooltosSubText.color = new Color(mooltosSubText.color.r, mooltosSubText.color.g, mooltosSubText.color.b, alpha);
            yield return null;
        }

        StartCoroutine(ExecuteMooltosNextEnable(3f));
    }

    IEnumerator ExecuteMooltosNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        mooltosNextButtonPanel.SetActive(true);
        float timeElapsed = 0;
        Color buttonColor = mooltosNext.image.color;

        while (timeElapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            buttonColor.a = alpha;
            mooltosNext.image.color = buttonColor;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        mooltosNext.interactable = true;
        mooltosPanel.SetActive(true);
        PauseTime();
        buttonColor.a = 1;
        mooltosNext.image.color = buttonColor;
    }

    public void StartTowerTilesTutorial()
    {
        StartCoroutine(ExecuteTowerTilesEnable(0.1f));
    }

    IEnumerator ExecuteTowerTilesEnable(float time)
    {
        yield return new WaitForSeconds(time);
        
        towerTilesMainText.color = new Color(towerTilesMainText.color.r, towerTilesMainText.color.g, towerTilesMainText.color.b, 0);
        towerTilesSubText.color = new Color(towerTilesSubText.color.r, towerTilesSubText.color.g, towerTilesSubText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            towerTilesMainText.color = new Color(towerTilesMainText.color.r, towerTilesMainText.color.g, towerTilesMainText.color.b, alpha);
            towerTilesSubText.color = new Color(towerTilesSubText.color.r, towerTilesSubText.color.g, towerTilesSubText.color.b, alpha);
            
            yield return null;
        }

        towerTilesPanel.SetActive(true);
        StartCoroutine(ExecuteTowerTilesNextEnable(0.1f));
    }

    IEnumerator ExecuteTowerTilesNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        towerTilesNextButtonPanel.SetActive(true);
        float timeElapsed = 0;
        Color buttonColor = towerTilesNext.image.color;

        while (timeElapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            buttonColor.a = alpha;
            towerTilesNext.image.color = buttonColor;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        towerTilesNext.interactable = true;
        PauseTime();
        buttonColor.a = 1;
        towerTilesNext.image.color = buttonColor;
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
