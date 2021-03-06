﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tower : MonoBehaviour {
    [SerializeField] public GameObject top;
    [SerializeField] public float Range = 10f;
    [SerializeField] ParticleSystem Guns;

    [SerializeField] public float Level = 1;

    public Waypoint waypoint;

    private Enemy target;

    private void Start()
    {
        Guns = FindObjectOfType<ParticleSystem>();
    }


    // Update is called once per frame
    void Update () {

        FindTraget();
        FocusOnTarget();
	}

    private void FocusOnTarget()
    {
        Shoot(false);

        if (target != null)
        {
            float distance = Vector3.Distance(gameObject.transform.position, target.transform.position);
            float leveledRange = Range + (Range * (Level / 10));
            if(distance < (leveledRange * (Level*0.1)))
            {
                Shoot(true);
                top.transform.LookAt(target.transform);
            }            
        }
    }

    private void Shoot(bool v)
    {
        var emissionModule = Guns.emission;
        emissionModule.enabled = v;
    }

    private void FindTraget()
    {
        float closestDistance;


        target = null;
        List<Enemy> EnemyList = FindObjectsOfType<Enemy>().ToList();
        if (EnemyList.Count == 0) { return; }


        target = EnemyList[0];
        closestDistance = Vector3.Distance(gameObject.transform.position, target.transform.position);


        foreach (var item in EnemyList)
        {
            float currentDistance = Vector3.Distance(gameObject.transform.position, item.transform.position);
            if (currentDistance < closestDistance)
            {
                target = item;
                closestDistance = currentDistance;
            }

        }

    }


    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            var TowerController = FindObjectOfType<TowerController>();
            TowerController.SelectedTower = gameObject.GetComponent<Tower>();
        }
    }

}
