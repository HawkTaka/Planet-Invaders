using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    const int GridSize = 10;
    Vector2Int GridPos;

    public bool isExplored = false;
    public Waypoint ExploredFrom;
    public bool isPlaceable = true;

    public Vector2Int  GetGridPos()
    {
        return new Vector2Int(
         Mathf.RoundToInt(this.transform.position.x / GridSize),
         Mathf.RoundToInt(this.transform.position.z / GridSize));
    }


    public int GetGridSize()
    {
        return GridSize;
    }


    public void SetTopColor(Color color)
    {
        var topMesh = transform.Find("Top").GetComponent<MeshRenderer>();
        topMesh.material.color = color;
    }




    private void OnMouseOver()
    {
        if (isPlaceable)
        {

            if (Input.GetMouseButton(0))
            {
                PlaceTower();
            }
            if (Input.GetMouseButton(1)) { print("button 1"); }
            if (Input.GetMouseButton(2)) { print("button 2"); }
        }
    }

    private void PlaceTower()
    {
        TowerController towerController = FindObjectOfType<TowerController>();
        towerController.PlaceTower(this);
        isPlaceable = false;
    }

    
}
