using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour {


    [SerializeField] public List<Waypoint> Path = new List<Waypoint>();
    [SerializeField] public float DwellTime = 1f;


	// Use this for initialization
	void Start ()
    {
        StartCoroutine(FollowPath());        
    }

    private IEnumerator FollowPath()
    {
        print("Starting Patrol");
        foreach (var pathItem in Path)
        {
            print("Visiting: "+pathItem.name);
            transform.position = pathItem.transform.position;
            yield return new WaitForSeconds(DwellTime);
        }
        print("Ending Patrol");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
