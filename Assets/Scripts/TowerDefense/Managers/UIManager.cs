using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    [Header("Panels")]
    [SerializeField] private GameObject towerShopPanel;
    [SerializeField] private GameObject nodeUIPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;

    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI upgradeText;
    [SerializeField] private TextMeshProUGUI sellText;
    [SerializeField] private TextMeshProUGUI towerLevelText;
    [SerializeField] private TextMeshProUGUI totalCoinsText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI currentWaveText;
    [SerializeField] private TextMeshProUGUI gameOverTotalCoinsText;
    
    private Node _currentNodeSelected;

    private void Update()
    {
        totalCoinsText.text = CurrencySystem.Instance.TotalCoins.ToString();
        livesText.text = LevelManager.Instance.TotalLives.ToString();
        currentWaveText.text = "Wave "+LevelManager.Instance.CurrentWave;
    }

    public void SlowTime()
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
    }

    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    public void ShowGameOverPanel()
    {
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
        SceneManager.LoadScene(4);
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
    }

    public void SellTower()
    {
        _currentNodeSelected.SellTower();
        _currentNodeSelected = null;
        nodeUIPanel.SetActive(false);
    }
    
    private void ShowNodeUI()
    {
        nodeUIPanel.SetActive(true);
        UpdateUpgradeText();
        UpdateTowerLevel();
        UpdateSellValue();
    }

    private void UpdateUpgradeText()
    {
        upgradeText.text = _currentNodeSelected.Tower.TowerUpgrade.UpgradeCost.ToString();
    }

    private void UpdateTowerLevel()
    {
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
