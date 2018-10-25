﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour {
    [SerializeField] public float DwellTime = 1f;
    List<Waypoint> path = new List<Waypoint>();

	// Use this for initialization
	void Start ()
    {

        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        path = pathFinder.GetPath();

        StartCoroutine(FollowPath());        
    }

    private IEnumerator FollowPath()
    {
        foreach (var pathItem in path)
        {
            transform.position = pathItem.transform.position;
            yield return new WaitForSeconds(DwellTime);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
