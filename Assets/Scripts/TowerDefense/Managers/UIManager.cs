using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("Panels")]
    [SerializeField] private GameObject towerShopPanel;
    [SerializeField] private GameObject nodeUIPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject coinPanel;
    [SerializeField] private GameObject wavePanel;

    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI upgradeText;
    [SerializeField] private TextMeshProUGUI sellText;
    [SerializeField] private TextMeshProUGUI towerLevelText;
    [SerializeField] private TextMeshProUGUI totalCoinsText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI currentWaveText;
    [SerializeField] private TextMeshProUGUI gameOverTotalCoinsText;

    [Header("Button")]
    [SerializeField] private Button towerUpgradeButton;
    
    [Header("PlayerPrefs")]
    [SerializeField] public string GoToAfterWin = "Cabin";
    [SerializeField] public int StageToUnlock;
    [SerializeField] public int StoryToUnlock;
    [SerializeField] public int FolktaleToUnlock;
    [SerializeField] public int RiddleToUnlock;
    [SerializeField] public int LegendToUnlock;
    [SerializeField] public int HumanToUnlock;
    [SerializeField] public int ToresToUnlock;
    [SerializeField] public int MooltosToUnlock;

    private int SkipIntroductionStory = 1;
    private int SkipTutorialStage = 1;
    private int SkipTutorialScene = 1;
    private int SkipStoryUnlock = 1;

    [Header("Scene Fader")]
    public SceneFader fader;

    private Node _currentNodeSelected;

    public void StartGame()
    {
        ResumeTime();
    }

    private void Update()
    {
        totalCoinsText.text = CurrencySystem.Instance.TotalCoins.ToString();
        livesText.text = LevelManager.Instance.TotalLives.ToString();
        int waveNum = LevelManager.Instance.CurrentWave;
        StartCoroutine(ExecuteAfterTime(5f, waveNum));
    }

    IEnumerator ExecuteAfterTime(float time, int waveNum)
    {
        yield return new WaitForSeconds(time);
        if (waveNum == Spawner.totalWave + 1)
        {
            waveNum = waveNum - 1;
            currentWaveText.text = "Wave "+ waveNum;
        }
        else if (waveNum <= Spawner.totalWave)
            currentWaveText.text = "Wave "+ waveNum;
    }

    /*public void SlowTime()
    {
        Time.timeScale = 0.5f;
    }*/

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    /*public void FastTime()
    {
        Time.timeScale = 2f;
    }*/

    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    public void ShowGameOverPanel()
    {
        coinPanel.SetActive(false);
        wavePanel.SetActive(false);
        gameOverPanel.SetActive(true);
        gameOverTotalCoinsText.text = CurrencySystem.Instance.TotalCoins.ToString();
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnCabin()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("stageReached", StageToUnlock);
        PlayerPrefs.SetInt("storyReached", StoryToUnlock);
        PlayerPrefs.SetInt("FolktaleBookSelector", FolktaleToUnlock);
        PlayerPrefs.SetInt("LegendBookSelector", LegendToUnlock);
        PlayerPrefs.SetInt("RiddleBookSelector", RiddleToUnlock);
        PlayerPrefs.SetInt("HumanBookSelector", HumanToUnlock);
        PlayerPrefs.SetInt("ToresBookSelector", ToresToUnlock);
        PlayerPrefs.SetInt("MooltosBookSelector", MooltosToUnlock);
        PlayerPrefs.SetInt("SkipIntroductionStory", SkipIntroductionStory);
        PlayerPrefs.SetInt("SkipTutorialStage", SkipTutorialStage);
        PlayerPrefs.SetInt("SkipTutorialScene", SkipTutorialScene);
        PlayerPrefs.SetInt("SkipStoryUnlock", SkipStoryUnlock);
        fader.FadeTo(GoToAfterWin);
    }
    
    public void CloseTowerShopPanel()
    {
        towerShopPanel.SetActive(false);
    }

    public void CloseNodeUIPanel()
    {
        _currentNodeSelected.CloseAttackRangeSprite();
        nodeUIPanel.SetActive(false);
    }
    
    public void UpgradeTower()
    {
        _currentNodeSelected.Tower.TowerUpgrade.UpgradeTower();
        UpdateUpgradeText();
        UpdateTowerLevel();
        UpdateSellValue();
        nodeUIPanel.SetActive(false);
    }

    public void SellTower()
    {
        _currentNodeSelected.SellTower();
        _currentNodeSelected = null;
        nodeUIPanel.SetActive(false);
    }
    
    private void ShowNodeUI()
    {
        if (_currentNodeSelected.Tower.TowerUpgrade.Level == 3)
            towerUpgradeButton.interactable = false;
        else
            towerUpgradeButton.interactable = true;

        nodeUIPanel.SetActive(true);
        UpdateUpgradeText();
        UpdateTowerLevel();
        UpdateSellValue();
    }

    private void UpdateUpgradeText()
    {
        if (_currentNodeSelected.Tower.TowerUpgrade.Level == 3)
            upgradeText.text = "0";
        else
            upgradeText.text = _currentNodeSelected.Tower.TowerUpgrade.UpgradeCost.ToString();
    }

    private void UpdateTowerLevel()
    {
        if (_currentNodeSelected.Tower.TowerUpgrade.Level == 3)
            towerLevelText.text = "Level Max";
        else
            towerLevelText.text = $"Level {_currentNodeSelected.Tower.TowerUpgrade.Level}";
    }

    private void UpdateSellValue()
    {
        int sellAmount = _currentNodeSelected.Tower.TowerUpgrade.GetSellValue();
        sellText.text = sellAmount.ToString();
    }
    
    private void NodeSelected(Node nodeSelected)
    {
        _currentNodeSelected = nodeSelected;
        if (_currentNodeSelected.IsEmpty())
        {
            towerShopPanel.SetActive(true);
        }
        else
        {
            ShowNodeUI();
        }
    }
    
    private void OnEnable()
    {
        Node.OnNodeSelected += NodeSelected;
    }

    private void OnDisable()
    {
        Node.OnNodeSelected -= NodeSelected;
    }
}
