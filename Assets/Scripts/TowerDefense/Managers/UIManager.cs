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
    [SerializeField] private GameObject countdownPanel;
    [SerializeField] private GameObject cheatPanel;

    [Header("Images")]
    [SerializeField] private Image countdownBlackImage;

    [Header("Text")] 
    [SerializeField] private TextMeshProUGUI upgradeText;
    [SerializeField] private TextMeshProUGUI sellText;
    [SerializeField] private TextMeshProUGUI towerLevelText;
    [SerializeField] private TextMeshProUGUI totalCoinsText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI currentWaveText;
    [SerializeField] private TextMeshProUGUI gameOverTotalCoinsText;
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private TextMeshProUGUI waveStartText;
    [SerializeField] private TextMeshProUGUI finalWaveStartText;

    [Header("Button")]
    [SerializeField] private Button towerUpgradeButton;
    [SerializeField] private Button cheatButton;
    
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
    [SerializeField] public int TowerToUnlock;

    [Header("PlayerPrefs Notification")]
    [SerializeField] public int FolktaleNewReward;
    [SerializeField] public int RiddleNewReward;
    [SerializeField] public int LegendNewReward;
    [SerializeField] public int HumanNewReward;
    [SerializeField] public int ToresNewReward;
    [SerializeField] public int MooltosNewReward;
    [SerializeField] public int EncyclopediaNewReward;
    [SerializeField] public int BookshelfNewReward;

    private int SkipIntroductionStory = 1;
    private int SkipTutorialStage = 1;
    private int SkipTutorialScene = 1;
    private int SkipStoryUnlock = 1;
    private int CabinButtonInteract = 1;
    private float fadeDuration = 1f;
    private float startingAlpha;
    private float startingAlpha2;

    private readonly KeyCode[] sequence = new KeyCode[]
    {
        KeyCode.UpArrow,
        KeyCode.UpArrow,
        KeyCode.DownArrow,
        KeyCode.DownArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow,
        KeyCode.LeftArrow,
        KeyCode.RightArrow
    };
    private readonly int[] sequence2 = new int[] { 1, 1, 2, 2, 3, 4, 3, 4 }; // 1 = up, 2 = down, 3 = left, 4 = right

    private int sequenceIndex = 0;
    private int sequenceIndex2 = 0;

    [Header("Scene Fader")]
    public SceneFader fader;

    private Node _currentNodeSelected;
    public CoinCheckerManager coinCheckerManager;

    [Header("Nodes")]
    public Button[] NodeButtons;

    public void StartGame()
    {
        ResumeTime();
    }

    private void Update()
    {
        // Mobile Touch 
        if (Input.GetKeyDown(sequence[sequenceIndex]))
        {
            sequenceIndex++;

            if (sequenceIndex == sequence.Length)
            {
                cheatPanel.SetActive(true);
                cheatButton.interactable = true;

                sequenceIndex = 0;
            }
        }
        else
        {
            sequenceIndex = 0;
        }

        // Desktop/Laptop Touch
        if (Input.GetMouseButtonDown(0)) // Check if left mouse button is clicked
        {
            Vector3 mousePos = Input.mousePosition; // Get mouse position
        }

        if (Input.GetMouseButtonDown(0))
        {
            int input = GetMouseInput();
            
            if (input == sequence2[sequenceIndex2])
            {
                sequenceIndex2++;

                if (sequenceIndex2 == sequence2.Length)
                {
                    cheatPanel.SetActive(true);
                    cheatButton.interactable = true;

                    sequenceIndex2 = 0;
                }
            }
            else
            {
                sequenceIndex2 = 0;
            }
        }

        totalCoinsText.text = CurrencySystem.Instance.TotalCoins.ToString();
        livesText.text = LevelManager.Instance.TotalLives.ToString();
        int waveNum = LevelManager.Instance.CurrentWave;
        StartCoroutine(ExecuteAfterTime(1f, waveNum));
    }

    private int GetMouseInput()
    {
        Vector2 mousePosition = Input.mousePosition;

        if (mousePosition.y > Screen.height / 2) // Mouse is in the upper half of the screen
        {
            if (mousePosition.x < Screen.width / 2) // Mouse is in the left third of the upper half
            {
                return 1; // Up
            }
            else if (mousePosition.x > Screen.width / 2) // Mouse is in the right third of the upper half
            {
                return 4; // Right
            }
        }
        else if (mousePosition.y < Screen.height / 2) // Mouse is in the lower half of the screen
        {
            if (mousePosition.x < Screen.width / 2) // Mouse is in the left third of the lower half
            {
                return 3; // Left
            }
            else if (mousePosition.x > Screen.width / 2) // Mouse is in the right third of the lower half
            {
                return 2; // Down
            }
        }

        return 0; // No direction detected
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Stage0")
        {
            int seconds = 16;
            StartCoroutine(ExecuteCountdownAfterTime(seconds, 1f));
        }
        else
        {
            int seconds = 5;
            StartCoroutine(ExecuteCountdownAfterTime(seconds, 1f));
        }
    }

    IEnumerator ExecuteCountdownAfterTime(int seconds, float time)
    {
        yield return new WaitForSeconds(time);

        if (seconds >= 1 && seconds <= 5)
        {
            countdownText.text = $"Enemy spawn in {seconds.ToString()} seconds";
            --seconds;
            StartCoroutine(ExecuteCountdownAfterTime(seconds, 1f));
        }
        else if (seconds == 0)
        {
            countdownText.text = $"Enemy spawn in {seconds.ToString()} seconds";
            --seconds;
            StartCoroutine(FadeOut());
        }
        else 
        {
            --seconds;
            StartCoroutine(ExecuteCountdownAfterTime(seconds, 1f));
        }
    }

    public void CheatCode() 
    {
        ResumeTime();
        int UnlockedStage = PlayerPrefs.GetInt("stageReached");

        int FolktaleCurrentUnlocked = PlayerPrefs.GetInt("FolktaleBookSelector");
        int LegendCurrentUnlocked = PlayerPrefs.GetInt("LegendBookSelector");
        int RiddleCurrentUnlocked = PlayerPrefs.GetInt("RiddleBookSelector");
        int ToresCurrentUnlocked = PlayerPrefs.GetInt("ToresBookSelector");
        int MooltosCurrentUnlocked = PlayerPrefs.GetInt("MooltosBookSelector");
        
        if (UnlockedStage <= StageToUnlock)
        {
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
            PlayerPrefs.SetInt("CabinButtonInteract", CabinButtonInteract);
            PlayerPrefs.SetInt("TowerToUnlock", TowerToUnlock);
            
            int FolktaleCurrentReward = PlayerPrefs.GetInt("FolktaleNewReward");
            int RiddleCurrentReward = PlayerPrefs.GetInt("RiddleNewReward");
            int LegendCurrentReward = PlayerPrefs.GetInt("LegendNewReward");
            int HumanCurrentReward = PlayerPrefs.GetInt("HumanNewReward");
            int ToresCurrentReward = PlayerPrefs.GetInt("ToresNewReward");
            int MooltosCurrentReward = PlayerPrefs.GetInt("MooltosNewReward");
            int EncyclopediaCurrentReward = PlayerPrefs.GetInt("EncyclopediaNewReward");
            int BookshelfCurrentReward = PlayerPrefs.GetInt("BookshelfNewReward");

            if (FolktaleCurrentReward != 1)
                PlayerPrefs.SetInt("FolktaleNewReward", FolktaleNewReward);
            if (RiddleCurrentReward != 1)
                PlayerPrefs.SetInt("RiddleNewReward", RiddleNewReward);
            if (LegendCurrentReward != 1)
                PlayerPrefs.SetInt("LegendNewReward", LegendNewReward);
            if (HumanCurrentReward != 1)
                PlayerPrefs.SetInt("HumanNewReward", HumanNewReward);
            if (ToresCurrentReward != 1)
                PlayerPrefs.SetInt("ToresNewReward", ToresNewReward);
            if (MooltosCurrentReward != 1)
                PlayerPrefs.SetInt("MooltosNewReward", MooltosNewReward);
            if (EncyclopediaCurrentReward != 1)
                PlayerPrefs.SetInt("EncyclopediaNewReward", EncyclopediaNewReward);
            if (BookshelfCurrentReward != 1)
                PlayerPrefs.SetInt("BookshelfNewReward", BookshelfNewReward);

            if (SceneManager.GetActiveScene().name == "Stage0")
            {
                for (int i = 0; i < 3; i++)
                {
                    PlayerPrefs.SetInt("Humans" + i, 1);
                }

                PlayerPrefs.SetInt("Tores0", 1);
                PlayerPrefs.SetInt("Mooltos0", 1);
            }
            else if (SceneManager.GetActiveScene().name == "Stage1")
            {
                for (int i = FolktaleCurrentUnlocked; i < FolktaleToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Folktales" + i, 1);
                }

                for (int i = RiddleCurrentUnlocked; i < RiddleToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Riddles" + i, 1);
                }

                for (int i = LegendCurrentUnlocked; i < LegendToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Legends" + i, 1);
                }
            }
            else 
            {
                for (int i = FolktaleCurrentUnlocked; i < FolktaleToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Folktales" + i, 1);
                }

                for (int i = RiddleCurrentUnlocked; i < RiddleToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Riddles" + i, 1);
                }

                for (int i = LegendCurrentUnlocked; i < LegendToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Legends" + i, 1);
                }
                
                for (int i = ToresCurrentUnlocked; i < ToresToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Tores" + i, 1);
                }

                for (int i = MooltosCurrentUnlocked; i < MooltosToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Mooltos" + i, 1);
                }
            }
        }

        fader.FadeTo(GoToAfterWin);
    }

    public void ShowWaveText() 
    {
        StartCoroutine(ExecuteWaveMessageFadeIn(0.1f));
    }

    IEnumerator ExecuteWaveMessageFadeIn(float time)
    {
        yield return new WaitForSeconds(time);
        
        waveStartText.text = $"Wave {LevelManager.Instance.CurrentWave.ToString()} will start now";
        waveStartText.color = new Color(waveStartText.color.r, waveStartText.color.g, waveStartText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            waveStartText.color = new Color(waveStartText.color.r, waveStartText.color.g, waveStartText.color.b, alpha);
            yield return null;
        }

        StartCoroutine(ExecuteWaveMessageFadeOut(2f));
    }

    IEnumerator ExecuteWaveMessageFadeOut(float time)
    {
        yield return new WaitForSeconds(time);

        float blinkInterval = 0.1f;
        waveStartText.color = new Color(waveStartText.color.r, waveStartText.color.g, waveStartText.color.b, 1);
        float timeElapsed = 0;
        float startAlpha = 1f; 
        float targetAlpha = 0f; 

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, timeElapsed / fadeDuration);
            waveStartText.color = new Color(waveStartText.color.r, waveStartText.color.g, waveStartText.color.b, alpha);

            if (timeElapsed % (2 * blinkInterval) < blinkInterval)
            {
                waveStartText.color = new Color(waveStartText.color.r, waveStartText.color.g, waveStartText.color.b, 0);
            }
            else
            {
                waveStartText.color = new Color(waveStartText.color.r, waveStartText.color.g, waveStartText.color.b, alpha);
            }

            yield return null;
        }
        AudioManager.Instance.PlaySound("WaveStart");
    }

    public void ShowLastWaveText() 
    {
        StartCoroutine(ExecuteLastWaveMessageFadeIn(0.1f));
    }

    IEnumerator ExecuteLastWaveMessageFadeIn(float time)
    {
        yield return new WaitForSeconds(time);
        
        finalWaveStartText.color = new Color(finalWaveStartText.color.r, finalWaveStartText.color.g, finalWaveStartText.color.b, 0);
        float timeElapsed = 0;

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, timeElapsed / fadeDuration);
            finalWaveStartText.color = new Color(finalWaveStartText.color.r, finalWaveStartText.color.g, finalWaveStartText.color.b, alpha);
            yield return null;
        }

        StartCoroutine(ExecuteLastWaveMessageFadeOut(2f));
    }

    IEnumerator ExecuteLastWaveMessageFadeOut(float time)
    {
        yield return new WaitForSeconds(time);

        float blinkInterval = 0.1f;
        finalWaveStartText.color = new Color(finalWaveStartText.color.r, finalWaveStartText.color.g, finalWaveStartText.color.b, 1);
        float timeElapsed = 0;
        float startAlpha = 1f; 
        float targetAlpha = 0f; 

        while (timeElapsed < fadeDuration)
        {
            timeElapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, timeElapsed / fadeDuration);
            finalWaveStartText.color = new Color(finalWaveStartText.color.r, finalWaveStartText.color.g, finalWaveStartText.color.b, alpha);

            if (timeElapsed % (2 * blinkInterval) < blinkInterval)
            {
                finalWaveStartText.color = new Color(finalWaveStartText.color.r, finalWaveStartText.color.g, finalWaveStartText.color.b, 0);
            }
            else
            {
                finalWaveStartText.color = new Color(finalWaveStartText.color.r, finalWaveStartText.color.g, finalWaveStartText.color.b, alpha);
            }

            yield return null;
        }
    }

    public void ClosePanelEnableInteractable()
    {
        for (int x = 0; x < NodeButtons.Length; x++)
        {
            NodeButtons[x].interactable = true;
        }
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
        {
            currentWaveText.text = "Wave "+ waveNum;
        }
    }

    IEnumerator FadeOut()
    {
        float t = 0f;
        startingAlpha = countdownBlackImage.color.a;
        startingAlpha2 = countdownText.color.a;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(startingAlpha, 0f, t / fadeDuration);
            float alpha2 = Mathf.Lerp(startingAlpha2, 0f, t / fadeDuration);
            countdownBlackImage.color = new Color(countdownBlackImage.color.r, countdownBlackImage.color.g, countdownBlackImage.color.b, alpha);
            countdownText.color = new Color(countdownText.color.r, countdownText.color.g, countdownText.color.b, alpha2);
            yield return null;
        }
        countdownPanel.SetActive(false);
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

        GameObject objToDestroy = GameObject.Find("AudioManager");
        if (objToDestroy != null) 
        {
            Destroy(objToDestroy);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnGameStageMap()
    {
        int UnlockedStage = PlayerPrefs.GetInt("stageReached");

        int FolktaleCurrentUnlocked = PlayerPrefs.GetInt("FolktaleBookSelector");
        int LegendCurrentUnlocked = PlayerPrefs.GetInt("LegendBookSelector");
        int RiddleCurrentUnlocked = PlayerPrefs.GetInt("RiddleBookSelector");
        int ToresCurrentUnlocked = PlayerPrefs.GetInt("ToresBookSelector");
        int MooltosCurrentUnlocked = PlayerPrefs.GetInt("MooltosBookSelector");

        Time.timeScale = 1f;
        if (UnlockedStage <= StageToUnlock && LevelManager.Instance.CurrentWave == Spawner.totalWave + 1 && Spawner._enemiesRemaining < 1)
        {
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
            PlayerPrefs.SetInt("CabinButtonInteract", CabinButtonInteract);
            PlayerPrefs.SetInt("TowerToUnlock", TowerToUnlock);
            
            PlayerPrefs.GetInt("FolktaleNewReward");
            PlayerPrefs.GetInt("RiddleNewReward");
            PlayerPrefs.GetInt("LegendNewReward");
            PlayerPrefs.GetInt("HumanNewReward");
            PlayerPrefs.GetInt("ToresNewReward");
            PlayerPrefs.GetInt("MooltosNewReward");
            PlayerPrefs.GetInt("EncyclopediaNewReward");
            PlayerPrefs.GetInt("BookshelfNewReward");

            if (FolktaleNewReward != 1)
                PlayerPrefs.SetInt("FolktaleNewReward", FolktaleNewReward);
            if (RiddleNewReward != 1)
                PlayerPrefs.SetInt("RiddleNewReward", RiddleNewReward);
            if (LegendNewReward != 1)
                PlayerPrefs.SetInt("LegendNewReward", LegendNewReward);
            if (HumanNewReward != 1)
                PlayerPrefs.SetInt("HumanNewReward", HumanNewReward);
            if (ToresNewReward != 1)
                PlayerPrefs.SetInt("ToresNewReward", ToresNewReward);
            if (MooltosNewReward != 1)
                PlayerPrefs.SetInt("MooltosNewReward", MooltosNewReward);
            if (EncyclopediaNewReward != 1)
                PlayerPrefs.SetInt("EncyclopediaNewReward", EncyclopediaNewReward);
            if (BookshelfNewReward != 1)
                PlayerPrefs.SetInt("BookshelfNewReward", BookshelfNewReward);

            if (SceneManager.GetActiveScene().name == "Stage0")
            {
                for (int i = 0; i < 3; i++)
                {
                    PlayerPrefs.SetInt("Humans" + i, 1);
                }

                PlayerPrefs.SetInt("Tores0", 1);
                PlayerPrefs.SetInt("Mooltos0", 1);
            }
            else
            {
                int FolktalesBooksNotified = PlayerPrefs.GetInt("FolktaleBookSelector") - 1;
                int RiddlesBooksNotified = PlayerPrefs.GetInt("RiddleBookSelector") - 1;
                int LegendsBooksNotified = PlayerPrefs.GetInt("LegendBookSelector") - 1;
                int ToresBooksNotified = PlayerPrefs.GetInt("ToresBookSelector") - 1;
                int MooltosBooksNotified = PlayerPrefs.GetInt("MooltosBookSelector") - 1;

                for (int i = FolktaleCurrentUnlocked; i < FolktaleToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Folktales" + i, 1);
                }

                for (int i = RiddleCurrentUnlocked; i < RiddleToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Riddles" + i, 1);
                }

                for (int i = LegendCurrentUnlocked; i < LegendToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Legends" + i, 1);
                }

                for (int i = ToresCurrentUnlocked; i < ToresToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Tores" + i, 1);
                }

                for (int i = MooltosCurrentUnlocked; i < MooltosToUnlock; i++)
                {
                    PlayerPrefs.SetInt("Mooltos" + i, 1);
                }
            }
        }

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
        if (CurrencySystem.Instance.TotalCoins >= _currentNodeSelected.Tower.TowerUpgrade.UpgradeCost)
        {
            _currentNodeSelected.Tower.TowerUpgrade.UpgradeTower();
            UpdateUpgradeText();
            UpdateTowerLevel();
            UpdateSellValue();
            nodeUIPanel.SetActive(false);
        }
        else
        {
            coinCheckerManager.ShowMessage();
        }
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
