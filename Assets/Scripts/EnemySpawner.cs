using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] [Range(0.1f, 120f)] float SecondsBetweenSpawns = 4f;
    [SerializeField] public GameObject EnemyToSpawn;
    [SerializeField] Text SpawnedEnemies;
    [SerializeField] AudioClip SpawnSFX;

    private int score = 0;

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
            score++;
            SpawnedEnemies.text = score.ToString();
            GetComponent<AudioSource>().PlayOneShot(SpawnSFX);

            Instantiate(EnemyToSpawn, transform.position, Quaternion.identity, gameObject.transform);
            yield return new WaitForSeconds(SecondsBetweenSpawns); 
        }
    }


}
