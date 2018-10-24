using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {
    [SerializeField] [Range(1f,20f)] float GridSize = 10f;
    TextMesh textMesh;


    void Start()
    {
              
    }

    // Update is called once per frame
    void Update ()
    {
        SnapToPosition();
    }

    private void SnapToPosition()
    {
        Vector3 snap = new Vector3();
        snap.x = Mathf.RoundToInt(this.transform.position.x / GridSize) * GridSize;
        snap.z = Mathf.RoundToInt(this.transform.position.z / GridSize) * GridSize;
        transform.position = new Vector3(snap.x, 0, snap.z);


        textMesh = GetComponentInChildren<TextMesh>();
        string postionText = (snap.x/GridSize).ToString() + "," + (snap.z/GridSize).ToString();
        textMesh.text = postionText;
        this.name = "Cube (" + postionText + ")";
    }
}
