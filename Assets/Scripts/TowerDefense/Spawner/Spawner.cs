using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public enum SpawnModes
{
    Fixed,
    Random
}

public class Spawner : MonoBehaviour
{
    public static Action OnWaveCompleted;
    
    [Header("Settings")]
    [SerializeField] private SpawnModes spawnMode = SpawnModes.Fixed;
    //[SerializeField] private int enemyCount = 10;
    [SerializeField] private float delayBtwWaves = 1f;

    [Header("Fixed Delay")]
    [SerializeField] private float delayBtwSpawns;
    
    [Header("Random Delay")]
    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;

    [Header("Poolers")] 
    /*[SerializeField] private ObjectPooler enemyWave1Pooler;
    [SerializeField] private ObjectPooler enemyWave2Pooler;
    [SerializeField] private ObjectPooler enemyWave3Pooler;*/
    [SerializeField] private ObjectPooler[] enemyWavePooler;
    [SerializeField] private ObjectPooler[] enemyWave2Pooler;

    private float _spawnTimer;

    private int enemyCount;
    private int enemyCount2;
    private int _enemiesSpawned;
    private int _enemiesSpawned2;
    private int _enemiesRemaining;
    
    public static int totalWave;
    private int Wave = 1;
    
    private Waypoint _waypoint;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Stage0")
		{
			_spawnTimer = 15f;
		}
        else
        {
            _spawnTimer = 5f;
        }
        
        _waypoint = GetComponent<Waypoint>();
        totalWave = Mathf.Min(enemyWavePooler.Length, enemyWave2Pooler.Length);

        _enemiesRemaining = enemyWavePooler[0].enemyCount + enemyWave2Pooler[0].enemyCount;
        enemyCount = enemyWavePooler[0].enemyCount;
        enemyCount2 = enemyWave2Pooler[0].enemyCount;
    }

    private void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0)
        {
            _spawnTimer = GetSpawnDelay();
            if (_enemiesSpawned < enemyCount)
            {
                _enemiesSpawned++;
                SpawnEnemy();
            }
            if (_enemiesSpawned2 < enemyCount2)
            {
                _enemiesSpawned2++;
                SpawnEnemy2();
            }
        }
    }

    private void SpawnEnemy()
    {
        try
        {
            GameObject newInstance = GetPooler().GetInstanceFromPool();
            Enemy enemy = newInstance.GetComponent<Enemy>();
            enemy.Waypoint = _waypoint;
            enemy.ResetEnemy();

            enemy.transform.localPosition = transform.position;
            newInstance.SetActive(true);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void SpawnEnemy2()
    {
        try
        {
            GameObject newInstance2 = GetPooler2().GetInstanceFromPool();
            Enemy enemy2 = newInstance2.GetComponent<Enemy>();
            enemy2.Waypoint = _waypoint;
            enemy2.ResetEnemy();

            enemy2.transform.localPosition = transform.position;
            newInstance2.SetActive(true);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private float GetSpawnDelay()
    {
        float delay = 0f;
        if (spawnMode == SpawnModes.Fixed)
        {
            delay = delayBtwSpawns;
        }
        else
        {
            delay = GetRandomDelay();
        }

        return delay;
    }
    
    private float GetRandomDelay()
    {
        float randomTimer = Random.Range(minRandomDelay, maxRandomDelay);
        return randomTimer;
    }

    private ObjectPooler GetPooler()
    {
        int currentWave = LevelManager.Instance.CurrentWave;
        for (int i = 0; i < enemyWavePooler.Length; i++)
        {
            try
            {
                if (currentWave < i) // 1- 10
                {
                    return enemyWavePooler[i];
                }

                if (currentWave > i && currentWave <= i+1) // 11- 20 and so on
                {
                    return enemyWavePooler[i];
                }
            }
            catch (System.Exception)
            {
                Debug.Log("Object Pooler Error!");
                throw;
            }
        }
        
        return null;
    }

    private ObjectPooler GetPooler2()
    {
        int currentWave = LevelManager.Instance.CurrentWave;
        for (int i = 0; i < enemyWave2Pooler.Length; i++)
        {
            try
            {
                if (currentWave < i) // 1- 10
                {
                    return enemyWave2Pooler[i];
                }

                if (currentWave > i && currentWave <= i+1) // 11- 20 and so on
                {
                    return enemyWave2Pooler[i];
                }
            }
            catch (System.Exception)
            {
                Debug.Log("Object Pooler Error!");
                throw;
            }
        }
        
        return null;
    }
    
    private IEnumerator NextWave(int Wave)
    {
        yield return new WaitForSeconds(delayBtwWaves);
        if (Wave < totalWave)
        {
            _enemiesRemaining = enemyWavePooler[Wave].enemyCount + enemyWave2Pooler[Wave].enemyCount;
            enemyCount = enemyWavePooler[Wave].enemyCount;
            enemyCount2 = enemyWave2Pooler[Wave].enemyCount;
            _spawnTimer = 0f;
            _enemiesSpawned = 0;
            _enemiesSpawned2 = 0;
        }
        else
        {
            Debug.Log("No More Waves!");
        }
    }
    
    private void RecordEnemy(Enemy enemy)
    {
        _enemiesRemaining--;
        if (_enemiesRemaining <= 0)
        {
            OnWaveCompleted?.Invoke();
            StartCoroutine(NextWave(Wave));
            Wave++;
        }
    }
    
    private void OnEnable()
    {
        Enemy.OnEndReached += RecordEnemy;
        EnemyHealth.OnEnemyKilled += RecordEnemy;
    }

    private void OnDisable()
    {
        Enemy.OnEndReached -= RecordEnemy;
        EnemyHealth.OnEnemyKilled -= RecordEnemy;
    }
}
