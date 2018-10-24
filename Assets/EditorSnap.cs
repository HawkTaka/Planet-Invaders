using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour {

    [SerializeField] [Range(1f,20f)] float GridSize = 10f;

	// Update is called once per frame
	void Update () {
        Vector3 snap = new Vector3();
        snap.x = Mathf.RoundToInt(this.transform.position.x / GridSize) * GridSize;
        snap.z = Mathf.RoundToInt(this.transform.position.z / GridSize) * GridSize;
        

        transform.position = new Vector3(snap.x, 0, snap.z);
	}
}
