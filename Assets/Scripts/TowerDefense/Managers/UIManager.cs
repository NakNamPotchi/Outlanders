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

    [SerializeField] private int SkipIntroductionStory = 1;
    [SerializeField] private int SkipTutorialStage = 1;
    [SerializeField] private int SkipTutorialScene = 1;

    [Header("Scene Fader")]
    public SceneFader fader;

    private Node _currentNodeSelected;

    private void Update()
    {
        totalCoinsText.text = CurrencySystem.Instance.TotalCoins.ToString();
        livesText.text = LevelManager.Instance.TotalLives.ToString();
        int waveNum = LevelManager.Instance.CurrentWave;
        if (waveNum == 4)
        {
            waveNum = waveNum - 1;
            currentWaveText.text = "Wave "+ waveNum;
        }
        else if (waveNum <= 3)
            currentWaveText.text = "Wave "+ waveNum;
    }

    /*public void SlowTime()
    {
        Time.timeScale = 0.5f;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1f;
    }

    public void FastTime()
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
        PlayerPrefs.SetInt("StorySelector", StoryToUnlock);
        PlayerPrefs.SetInt("FolktaleLevelSelector", FolktaleToUnlock);
        PlayerPrefs.SetInt("LegendLevelSelector", LegendToUnlock);
        PlayerPrefs.SetInt("RiddleLevelSelector", RiddleToUnlock);
        PlayerPrefs.SetInt("HumanLevelSelector", HumanToUnlock);
        PlayerPrefs.SetInt("ToresLevelSelector", ToresToUnlock);
        PlayerPrefs.SetInt("MooltosLevelSelector", MooltosToUnlock);
        PlayerPrefs.SetInt("SkipIntroductionStory", SkipIntroductionStory);
        PlayerPrefs.SetInt("SkipTutorialStage", SkipTutorialStage);
        PlayerPrefs.SetInt("SkipTutorialScene", SkipTutorialScene);
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
