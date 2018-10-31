using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPanelUI : MonoBehaviour {

    public Button btnUpgrade;

    [SerializeField] Text lblLevel;
    private Tower SelectedTower;


    private void Start()
    {
        btnUpgrade.onClick.AddListener(UpgradeTower);
    }

    private void UpgradeTower()
    {
        //TODO:Use some resources
        SelectedTower.Level++;

        UpdateUI();
    }

    internal void SetTower(Tower selectedTower)
    {
        SelectedTower = selectedTower;
        gameObject.SetActive(true);
        UpdateUI();
    }

    private void UpdateUI()
    {
        lblLevel.text = SelectedTower.Level.ToString();
    }
}
