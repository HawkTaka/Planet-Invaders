using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour {
    [SerializeField] public float DwellTime = 1f;
    List<Waypoint> path = new List<Waypoint>();
    [SerializeField] ParticleSystem GoalParticle;
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
            Vector3 newPos = new Vector3(pathItem.transform.position.x,10, pathItem.transform.position.z);
            transform.position = newPos;

            //transform.position = pathItem.transform.position;

            yield return new WaitForSeconds(DwellTime);
        }

        SelfDestruct();
    }


    private void SelfDestruct()
    {
        var deathFX = Instantiate(GoalParticle, transform.position, Quaternion.identity);
        deathFX.Play();
        float playtime = deathFX.main.duration;
        Destroy(deathFX.gameObject, playtime);
        Destroy(gameObject);
    }

}
