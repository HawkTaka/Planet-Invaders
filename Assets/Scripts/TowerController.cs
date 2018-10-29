using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    [SerializeField] public Tower TowerToPlace;
    [SerializeField] int TowerLimit = 5;
    Queue<Tower> TowersPlaced = new Queue<Tower>();

    public void PlaceTower(Waypoint waypoint)
    {
        Vector3 placementLocation = new Vector3(waypoint.transform.position.x,
                                                waypoint.transform.position.y + 10f,
                                                waypoint.transform.position.z);

        if (TowersPlaced.Count >= TowerLimit)
        {
            MoveExistingTower(waypoint, placementLocation);
        }
        else
        {
            InstantiateNewTower(waypoint, placementLocation);
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
}
