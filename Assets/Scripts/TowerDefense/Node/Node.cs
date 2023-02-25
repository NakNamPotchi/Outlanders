using System;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static Action<Node> OnNodeSelected;
    public static Action OnTowerSold;

    [SerializeField] private GameObject attackRangeSprite;
    
    public Tower Tower { get; set; }

    private float _rangeSize;
    private Vector3 _rangeOriginalSize;

    private void Start()
    {
        _rangeSize = attackRangeSprite.GetComponent<SpriteRenderer>().bounds.size.y;
        _rangeOriginalSize = attackRangeSprite.transform.localScale;
    }
    public void SetTower(Tower tower)
    {
        Tower = tower;
    }
    public bool IsEmpty()
    {
        return Tower == null;
    }
    public void CloseAttackRangeSprite()
    {
        attackRangeSprite.SetActive(false);
    }
    public void SelectTower()
    {
        OnNodeSelected?.Invoke(this);
        if (!IsEmpty())
        {
            ShowTowerInfo();
        }
    }
    public void SellTower()
    {
        if (!IsEmpty())
        {
            CurrencySystem.Instance.AddCoins(Tower.TowerUpgrade.GetSellValue());
            Destroy(Tower.gameObject);
            Tower = null;
            attackRangeSprite.SetActive(false);
            OnTowerSold?.Invoke();
        }
    }

    private void ShowTowerInfo()
    {
        attackRangeSprite.SetActive(true);
        attackRangeSprite.transform.localScale = _rangeOriginalSize * Tower.AttackRange / (_rangeSize / 2);
    }
}
