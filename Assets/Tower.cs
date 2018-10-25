using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    Enemy enemy;
    [SerializeField] public GameObject top;


    private void Start()
    {
        enemy = FindObjectOfType<Enemy>();
    }


    // Update is called once per frame
    void Update () {
        top.transform.LookAt(enemy.transform);


	}
}
