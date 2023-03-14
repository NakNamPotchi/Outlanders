using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShopManager : MonoBehaviour
{
    [SerializeField] private GameObject towerCardPrefab;
    [SerializeField] private GameObject lockedTowerCardPrefab;
    [SerializeField] private Transform towerPanelContainer;

    [Header("Tower Settings")]
    [SerializeField] private TowerSettings[] towers;

    private Node _currentNodeSelected;
    private int TowerToUnlock;
    
    private void Start()
    {
        int TowerToUnlock = PlayerPrefs.GetInt("TowerToUnlock");

        for (int i = 0; i < towers.Length; i++)
        {
            if (TowerToUnlock >= i)
            {
                CreateTowerCard(towers[i]); 
            }
            else
            {
                CreateBlankTowerCard(towers[i]);           
            }
        }
    }

    private void CreateTowerCard(TowerSettings towerSettings)
    {
        GameObject newInstance = Instantiate(towerCardPrefab, towerPanelContainer.position, Quaternion.identity);
        newInstance.transform.SetParent(towerPanelContainer);
        newInstance.transform.localScale = Vector3.one;

        TowerCard cardButton = newInstance.GetComponent<TowerCard>();
        cardButton.SetupTowerButton(towerSettings);
    }

    private void CreateBlankTowerCard(TowerSettings towerSettings)
    {
        GameObject newInstance = Instantiate(lockedTowerCardPrefab, towerPanelContainer.position, Quaternion.identity);
        newInstance.transform.SetParent(towerPanelContainer);
        newInstance.transform.localScale = Vector3.one;

        TowerCard cardButton = newInstance.GetComponent<TowerCard>();
        cardButton.SetupBlankTowerButton(towerSettings);
    }
    
    private void NodeSelected(Node nodeSelected)
    {
        _currentNodeSelected = nodeSelected;
    }
    
    private void PlaceTower(TowerSettings towerLoaded)
    {
        if (_currentNodeSelected != null)
        {
            GameObject towerInstance = Instantiate(towerLoaded.TowerPrefab);
            towerInstance.transform.localPosition = _currentNodeSelected.transform.position;
            towerInstance.transform.parent = _currentNodeSelected.transform;

            Tower towerPlaced = towerInstance.GetComponent<Tower>();
            _currentNodeSelected.SetTower(towerPlaced);
        }
    }

    private void TowerSold()
    {
        _currentNodeSelected = null;
    }
    
    private void OnEnable()
    {
        Node.OnNodeSelected += NodeSelected;
        Node.OnTowerSold += TowerSold;
        TowerCard.OnPlaceTower += PlaceTower;
    }

    private void OnDisable()
    {
        Node.OnNodeSelected -= NodeSelected;
        Node.OnTowerSold -= TowerSold;
        TowerCard.OnPlaceTower -= PlaceTower;
    }
}
