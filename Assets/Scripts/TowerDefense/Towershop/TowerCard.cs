using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerCard : MonoBehaviour
{
    public static Action<TowerSettings> OnPlaceTower;
    
    [SerializeField] private Image towerImage;
    [SerializeField] private TextMeshProUGUI towerCost;

    public TowerSettings TowerLoaded { get; set; }

    public void SetupTowerButton(TowerSettings towerSettings)
    {
        TowerLoaded = towerSettings;
        towerImage.sprite = towerSettings.TowerShopSprite;
        towerCost.text = towerSettings.TowerShopCost.ToString();
    }

    public void SetupBlankTowerButton(TowerSettings towerSettings)
    {
        Sprite QuestionMark = Resources.Load<Sprite>("QuestionMark");

        TowerLoaded = towerSettings;
        towerImage.sprite = QuestionMark;
        towerCost.text = "0";
    }

    public void PlaceTower()
    {
        if (CurrencySystem.Instance.TotalCoins >= TowerLoaded.TowerShopCost)
        {
            CurrencySystem.Instance.RemoveCoins(TowerLoaded.TowerShopCost);
            UIManager.Instance.CloseTowerShopPanel();
            OnPlaceTower?.Invoke(TowerLoaded);
        }
    }
}
