﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour {

    [SerializeField] int PlayerHealthPoints = 10;
    [SerializeField] Text PlayerHealthUI;

    private void Start()
    {
        PlayerHealthUI.text = PlayerHealthPoints.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        print("losing HP");

        PlayerHealthPoints--;
        PlayerHealthUI.text = PlayerHealthPoints.ToString();

        if (PlayerHealthPoints <= 0)
        {
            //Stop Game Loop ?
        }
    }
}