﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3SceneRestartButton : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject triggers;
    private bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 1)
        {
            Debug.Log("timescale == 0");
            restartButton.SetActive(false);
        }
        else
        {
            Debug.Log("timescale == 1");
            restartButton.SetActive(true);
        }
    }

}