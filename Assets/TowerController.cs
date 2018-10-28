using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour {

    [SerializeField] public Tower TowerToPlace;
    [SerializeField] int TowerLimit = 5;


    public void PlaceTower(Waypoint waypoint)
    {
        
        Vector3 placementLocation = new Vector3(waypoint.transform.position.x,
                                                waypoint.transform.position.y + 10f,
                                                waypoint.transform.position.z);
        Instantiate(TowerToPlace, placementLocation, Quaternion.identity, gameObject.transform);

    }

}
