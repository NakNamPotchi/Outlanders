using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    [SerializeField] private int upgradeInitialCost;
    [SerializeField] private int upgradeCostIncremental;
    [SerializeField] private float damageIncremental;
    [SerializeField] private float delayReduce;

    [Header("Sell")] 
    [Range(0,1)]
    [SerializeField] private float sellPert;
    
    public float SellPerc { get; set; }
    public int UpgradeCost { get; set; }
    public int Level { get; set; }
    
    private TowerProjectile _towerProjectile;
    
    private void Start()
    {
        _towerProjectile = GetComponent<TowerProjectile>();
        UpgradeCost = upgradeInitialCost;

        SellPerc = sellPert;
        Level = 1;
    }
    
    public void UpgradeTower()
    {
        if (CurrencySystem.Instance.TotalCoins >= UpgradeCost)
        {
            _towerProjectile.Damage += damageIncremental;
            _towerProjectile.DelayPerShot -= delayReduce;
            UpdateUpgrade();
        }
    }

    public int GetSellValue()
    {
        int sellValue = Mathf.RoundToInt(UpgradeCost * SellPerc);
        return sellValue;
    }
    
    private void UpdateUpgrade()
    {
        if (Level < 3)
        {
            CurrencySystem.Instance.RemoveCoins(UpgradeCost);
            UpgradeCost += upgradeCostIncremental;
            Level++;
        }
    }
}
