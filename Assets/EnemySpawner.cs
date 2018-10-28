using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] [Range(0.1f, 120f)] float SecondsBetweenSpawns = 4f;
    [SerializeField] public GameObject EnemyToSpawn;


    private void Start()
    {
       if (EnemyToSpawn == null)
        {
            print("EnemySpawner: noting to spawn");
            return;
        }

        StartCoroutine(Spawn());
    }



    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(EnemyToSpawn, transform.position, Quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(SecondsBetweenSpawns); 
        }
    }


}
