using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    [SerializeField] public Tower TowerToPlace;
    [SerializeField] int TowerLimit = 5;
    Queue<Tower> TowersPlaced = new Queue<Tower>();

    private Tower selectedTower;


    public void PlaceTower(Waypoint waypoint)
    {
        Vector3 placementLocation = new Vector3(waypoint.transform.position.x,
                                                waypoint.transform.position.y + 10f,
                                                waypoint.transform.position.z);

        CheckTowerSelection(waypoint);


        if (TowersPlaced.Count >= TowerLimit)
        {
            MoveExistingTower(waypoint, placementLocation);
        }
        else
        {
            InstantiateNewTower(waypoint, placementLocation);
        }

    }

    private void CheckTowerSelection(Waypoint waypoint)
    {
        //SelectedTower = null;
        foreach (Tower item in TowersPlaced)
        {
            if (item.waypoint == waypoint)
            {
                SelectedTower = item;
                break;
            }
        }
    }

    private void InstantiateNewTower(Waypoint waypoint, Vector3 placementLocation)
    {
        //Create new instance
        Tower tower = Instantiate(TowerToPlace, placementLocation, Quaternion.identity, gameObject.transform);
        tower.waypoint = waypoint;
        tower.waypoint.isPlaceable = false;

        TowersPlaced.Enqueue(tower);
    }

    private void MoveExistingTower(Waypoint waypoint, Vector3 placementLocation)
    {
        //Move Tower
        Tower tower = TowersPlaced.Dequeue();
        tower.waypoint.isPlaceable = true;

        tower.waypoint = waypoint;
        tower.transform.position = placementLocation;
        TowersPlaced.Enqueue(tower);
    }


    public Tower SelectedTower {
        get { return selectedTower; }
        set
        {
            selectedTower = value;
            //Update UI

            var TowerUI = FindObjectOfType<TowerPanelUI>();
            TowerUI.SetTower(SelectedTower);
        }
    }

}
