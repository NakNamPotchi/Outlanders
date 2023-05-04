using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuklayTowerProjectile : TowerProjectile
{
    protected override void Update()
    {
        if (Time.time > _nextAttackTime)
        {
            if (_tower.CurrentEnemyTarget != null 
                && _tower.CurrentEnemyTarget.EnemyHealth.CurrentHealth > 0)
            {
                FireProjectile(_tower.CurrentEnemyTarget);
            }
            
            _nextAttackTime = Time.time + delayBtwAttacks;
        }
    }

    protected override void LoadProjectile() { }

    private void FireProjectile(Enemy enemy)
    {
        GameObject instance = _pooler.GetInstanceFromPool();
        instance.transform.position = projectileSpawnPosition.position;

        Projectile projectile = instance.GetComponent<Projectile>();
        _currentProjectileLoaded = projectile;
        _currentProjectileLoaded.TowerOwner = this;
        _currentProjectileLoaded.ResetProjectile();
        _currentProjectileLoaded.SetEnemy(enemy);
        _currentProjectileLoaded.Damage = Damage;
        instance.SetActive(true);
        AudioManager.Instance.PlaySound("Suklay");
    }
}
