using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    [SerializeField] protected Transform projectileSpawnPosition;
    [SerializeField] protected float delayBtwAttacks = 2f;
    [SerializeField] protected float damage = 2f;

    public float Damage { get; set; }
    public float DelayPerShot { get; set; }
    
    protected float _nextAttackTime;
    protected ObjectPooler _pooler;
    protected Tower _tower;
    protected Projectile _currentProjectileLoaded;

    private void Start()
    {
        _tower = GetComponent<Tower>();
        _pooler = GetComponent<ObjectPooler>();

        Damage = damage;
        DelayPerShot = delayBtwAttacks;
        LoadProjectile();
    }

    protected virtual void Update()
    {
        if (IsTowerEmpty())
        {
            LoadProjectile();
        }

        if (Time.time > _nextAttackTime)
        {
            if (_tower.CurrentEnemyTarget != null && _currentProjectileLoaded != null &&
                _tower.CurrentEnemyTarget.EnemyHealth.CurrentHealth > 0f)
            {
                _currentProjectileLoaded.transform.parent = null;
                _currentProjectileLoaded.SetEnemy(_tower.CurrentEnemyTarget);
                AudioManager.Instance.PlayerSound(AudioManager.Sound.Pinya);
            }

            _nextAttackTime = Time.time + DelayPerShot;
        }
    }

    protected virtual  void LoadProjectile()
    {
        GameObject newInstance = _pooler.GetInstanceFromPool();
        newInstance.transform.localPosition = projectileSpawnPosition.position;
        newInstance.transform.SetParent(projectileSpawnPosition);

        _currentProjectileLoaded = newInstance.GetComponent<Projectile>();
        _currentProjectileLoaded.TowerOwner = this;
        _currentProjectileLoaded.ResetProjectile();
        _currentProjectileLoaded.Damage = Damage;
        newInstance.SetActive(true);
    }

    private bool IsTowerEmpty()
    {
        return _currentProjectileLoaded == null;
    }
    
    public void ResetTowerProjectile()
    {
        _currentProjectileLoaded = null;
    }
}