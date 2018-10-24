using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmemyMovment : MonoBehaviour {


    [SerializeField] public List<Block> Path = new List<Block>();

	// Use this for initialization
	void Start ()
    {
        PrintAllWaypoints();
    }

    private void PrintAllWaypoints()
    {
        foreach (var pathItem in Path)
        {
            print(pathItem.name);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
