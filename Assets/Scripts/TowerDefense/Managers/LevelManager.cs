using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private int lives = 10;

    public int TotalLives { get; set; }
    public int CurrentWave { get; set; }
    
    private void Start()
    {
        TotalLives = lives;
        CurrentWave = 1;
    }

    private void ReduceLives(Enemy enemy)
    {
        TotalLives--;
        if (TotalLives <= 0)
        {
            TotalLives = 0;
            GameOver();
        }
    }

    private void GameOver()
    {
        UIManager.Instance.ShowGameOverPanel();
        UIManager.Instance.PauseTime();
    }

    private void YouWin()
    {
        StartCoroutine(ExecuteAfterTime(4));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        UIManager.Instance.ShowWinPanel();
        UIManager.Instance.PauseTime();
    }

    private void WaveCompleted()
    {
        CurrentWave++;
        if (CurrentWave == 4)
            YouWin();
    }
    
    private void OnEnable()
    {
        Enemy.OnEndReached += ReduceLives;
        Spawner.OnWaveCompleted += WaveCompleted;
    }

    private void OnDisable()
    {
        Enemy.OnEndReached -= ReduceLives;
        Spawner.OnWaveCompleted -= WaveCompleted;
    }
}
