using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    const int GridSize = 10;
    Vector2Int GridPos;

    public Vector2Int  GetGridPos()
    {
        return new Vector2Int(
         Mathf.RoundToInt(this.transform.position.x / GridSize) * GridSize,
         Mathf.RoundToInt(this.transform.position.z / GridSize) * GridSize);
    }


    public int GetGridSize()
    {
        return GridSize;
    }

}
