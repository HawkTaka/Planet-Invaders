using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint StartWaypoint, EndWaypoint;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;

    internal List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        PathFinde();

        return Path;
    }

    public List<Waypoint> Path = new List<Waypoint>();


    Vector2Int[] Directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    private void PathFinde()
    {
        queue.Enqueue(StartWaypoint);

        while(queue.Count >0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }

        BuildPath();
    }

    private void BuildPath()
    {
        Path.Add(EndWaypoint);

        Waypoint previous = EndWaypoint.ExploredFrom;
        while(previous != StartWaypoint)
        {
            Path.Add(previous);
            previous = previous.ExploredFrom;
        }
        Path.Add(StartWaypoint);

        Path.Reverse();
        
    }

    private void HaltIfEndFound()
    {
        if (searchCenter == EndWaypoint)
        {
            //Found End Point Get Path.
            isRunning = false;
        }
    }

    private void LoadBlocks()
    {
        var waypointList = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypointList)
        {
            bool isOverLapping = grid.ContainsKey(waypoint.GetGridPos());

            if (isOverLapping)
            {
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
        if(!isRunning) { return; }


        foreach (var direction in Directions)
        {
            Vector2Int explorationCoords = searchCenter.GetGridPos() + direction;

            if (grid.ContainsKey(explorationCoords))
            {
                QueueNewNeighbour(grid[explorationCoords]);
            }

        }
    }

    private void QueueNewNeighbour(Waypoint newWaypoint)
    {
        Waypoint neighbour = newWaypoint;
        if (neighbour.isExplored || queue.Contains(newWaypoint))
            return;

        neighbour.ExploredFrom = searchCenter;
        queue.Enqueue(neighbour);
    }
}
