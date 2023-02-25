using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShopManager : MonoBehaviour
{
    [SerializeField] private GameObject TowerCardPrefab;
    [SerializeField] private Transform TowerPanelContainer;

    [Header("Tower Settings")]
    [SerializeField] private TowerSettings[] Towers;

    private Node _currentNodeSelected;
    
    private void Start()
    {
        for (int i = 0; i < Towers.Length; i++)
        {
            CreateTowerCard(Towers[i]);
        }
    }

    private void CreateTowerCard(TowerSettings TowerSettings)
    {
        GameObject newInstance = Instantiate(TowerCardPrefab, TowerPanelContainer.position, Quaternion.identity);
        newInstance.transform.SetParent(TowerPanelContainer);
        newInstance.transform.localScale = Vector3.one;

        TowerCard cardButton = newInstance.GetComponent<TowerCard>();
        cardButton.SetupTowerButton(TowerSettings);
    }
    
    private void NodeSelected(Node nodeSelected)
    {
        _currentNodeSelected = nodeSelected;
    }
    
    private void PlaceTower(TowerSettings TowerLoaded)
    {
        if (_currentNodeSelected != null)
        {
            GameObject TowerInstance = Instantiate(TowerLoaded.TowerPrefab);
            TowerInstance.transform.localPosition = _currentNodeSelected.transform.position;
            TowerInstance.transform.parent = _currentNodeSelected.transform;

            Tower TowerPlaced = TowerInstance.GetComponent<Tower>();
            _currentNodeSelected.SetTower(TowerPlaced);
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
