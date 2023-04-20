using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [Header("Panels")]
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
    [SerializeField] private GameObject upgradeSellPanel;
    [SerializeField] private GameObject smallCanvasBlackBackground;

    [Header("Button")]
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
    [SerializeField] private TextMeshProUGUI upgradeSellMainText;

    [Header("ClickText")]
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private TextMeshProUGUI waveArrowText;
    [SerializeField] private TextMeshProUGUI coinsHeartsText;
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI enemyPathText;
    [SerializeField] private TextMeshProUGUI mooltosText;
    [SerializeField] private TextMeshProUGUI towerTilesText;

    private float fadeDuration = 1f;
    private float startingAlpha;
    private float executedOnce = 0;

    private void Start()
    {
        ResumeTime();
        StartCountdownTutorial();
    }

    public void StartCountdownTutorial()
    {
        StartCoroutine(ExecuteCountdownEnable(0.1f));
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

        StartCoroutine(ExecuteCountdownNextEnable(0.5f));
    }

    IEnumerator ExecuteCountdownNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        countdownNextButtonPanel.SetActive(true);
        countdownText.color = new Color(countdownText.color.r, countdownText.color.g, countdownText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            countdownText.color = new Color(countdownText.color.r, countdownText.color.g, countdownText.color.b, alpha);
            yield return null;
        }

        countdownNext.interactable = true;
        PauseTime();
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

        StartCoroutine(ExecuteWaveArrowNextEnable(0.5f));
    }

    IEnumerator ExecuteWaveArrowNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        waveArrowNextButtonPanel.SetActive(true);
        waveArrowText.color = new Color(waveArrowText.color.r, waveArrowText.color.g, waveArrowText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            waveArrowText.color = new Color(waveArrowText.color.r, waveArrowText.color.g, waveArrowText.color.b, alpha);
            yield return null;
        }

        waveArrowNext.interactable = true;
        PauseTime();
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

        StartCoroutine(ExecuteCoinsHeartNextEnable(0.5f));
    }

    IEnumerator ExecuteCoinsHeartNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        coinsHeartsNextButtonPanel.SetActive(true);
        coinsHeartsText.color = new Color(coinsHeartsText.color.r, coinsHeartsText.color.g, coinsHeartsText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            coinsHeartsText.color = new Color(coinsHeartsText.color.r, coinsHeartsText.color.g, coinsHeartsText.color.b, alpha);
            yield return null;
        }

        coinsHeartsNext.interactable = true;
        PauseTime();
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

        StartCoroutine(ExecuteWaveNextEnable(0.5f));
    }

    IEnumerator ExecuteWaveNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        waveNextButtonPanel.SetActive(true);
        waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            waveText.color = new Color(waveText.color.r, waveText.color.g, waveText.color.b, alpha);
            yield return null;
        }

        waveNext.interactable = true;
        PauseTime();
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

        StartCoroutine(ExecuteEnemyPathNextEnable(0.5f));
    }

    IEnumerator ExecuteEnemyPathNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        enemyPathNextButtonPanel.SetActive(true);
        enemyPathText.color = new Color(enemyPathText.color.r, enemyPathText.color.g, enemyPathText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            enemyPathText.color = new Color(enemyPathText.color.r, enemyPathText.color.g, enemyPathText.color.b, alpha);
            yield return null;
        }

        enemyPathNext.interactable = true;
        PauseTime();
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

        mooltosPanel.SetActive(true);
        StartCoroutine(ExecuteMooltosNextEnable(1f));
    }

    IEnumerator ExecuteMooltosNextEnable(float time)
    {
        yield return new WaitForSeconds(time);
        mooltosNextButtonPanel.SetActive(true);
        mooltosText.color = new Color(mooltosText.color.r, mooltosText.color.g, mooltosText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            mooltosText.color = new Color(mooltosText.color.r, mooltosText.color.g, mooltosText.color.b, alpha);
            yield return null;
        }

        mooltosNext.interactable = true;
        PauseTime();
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
        towerTilesText.color = new Color(towerTilesText.color.r, towerTilesText.color.g, towerTilesText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            towerTilesText.color = new Color(towerTilesText.color.r, towerTilesText.color.g, towerTilesText.color.b, alpha);
            yield return null;
        }

        towerTilesNext.interactable = true;
        PauseTime();
    }

    public void StartUpgradeSellTutorial()
    {
        if (executedOnce == 0)
        {
            StartCoroutine(ExecuteUpgradeSellEnable(1f));
        }
        else
        {
            StartCoroutine(ExecuteUpgradeSellEnable(99f));
        }
    }

    IEnumerator ExecuteUpgradeSellEnable(float time)
    {
        yield return new WaitForSeconds(time);
        
        upgradeSellPanel.SetActive(true);
        upgradeSellMainText.color = new Color(upgradeSellMainText.color.r, upgradeSellMainText.color.g, upgradeSellMainText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            upgradeSellMainText.color = new Color(upgradeSellMainText.color.r, upgradeSellMainText.color.g, upgradeSellMainText.color.b, alpha);
            
            if (timeElapsed > 0.8)
            {
                smallCanvasBlackBackground.SetActive(true);
            }
            executedOnce = 1;

            yield return null;
        }
        StartCoroutine(ExecuteUpgradeSellDisable(8f));
    }

    IEnumerator ExecuteUpgradeSellDisable(float time)
    {
        yield return new WaitForSeconds(time);
        
        upgradeSellPanel.SetActive(false);
        smallCanvasBlackBackground.SetActive(false);

        yield return null;
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
