using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {


    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();


	// Use this for initialization
	void Start () {
        LoadBlocks();
	}

    private void LoadBlocks()
    {
        var waypointList = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypointList)
        {
            bool isOverLapping = grid.ContainsKey(waypoint.GetGridPos());

            if (isOverLapping)
            {
                Debug.LogWarning("SKipping overlapping block " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }

        print("Loaded Grid Total blocks :" + grid.Count);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
