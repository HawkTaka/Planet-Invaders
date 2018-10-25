using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {

    const int GridSize = 10;
    Waypoint waypoint;
    
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }


    // Update is called once per frame
    void Update ()
    {
        SnapToPosition();
        UpdateLable();
    }

    private void UpdateLable()
    {
        int GridSize = waypoint.GetGridSize();

        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string postionText = (waypoint.GetGridPos().x).ToString() + "," + (waypoint.GetGridPos().y).ToString();
        textMesh.text = postionText;
        this.name = "Cube (" + postionText + ")";
    }

    private void SnapToPosition()
    {
        waypoint = GetComponent<Waypoint>();

        transform.position = new Vector3(
            waypoint.GetGridPos().x * waypoint.GetGridSize(),
            0,
            waypoint.GetGridPos().y * waypoint.GetGridSize());
    }
}
