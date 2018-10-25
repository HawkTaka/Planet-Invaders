using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {


    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint StartWaypoint, EndWaypoint;

    Vector2Int[] Directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    // Use this for initialization
    void Start () {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbours();

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
                waypoint.SetTopColor(Color.gray);
            }
        }

        print("Loaded Grid Total blocks :" + grid.Count);
    }

    private void ColorStartAndEnd()
    {
        StartWaypoint.SetTopColor(Color.green);
        EndWaypoint.SetTopColor(Color.red);
    }
    

    private void ExploreNeighbours()
    {
        foreach (var direction in Directions)
        {
            Vector2Int explorationCoords = StartWaypoint.GetGridPos() + direction;
            print("Exploring" + explorationCoords);


            if (grid.ContainsKey(explorationCoords))
            {
                grid[explorationCoords].SetTopColor(Color.blue);
            }

        }
    }

}
