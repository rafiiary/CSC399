﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyActiveWhenCarIs : MonoBehaviour
{
    public GameObject car;
    public GameObject codeExecution;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject aniCamera;
    public GameObject dragandDrop;
    // Start is called before the first frame update
    void Start()
    {
        codeExecution.SetActive(false);
        one.SetActive(false);
        two.SetActive(false);
        three.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (car.active == true & aniCamera.active == false & dragandDrop.active == false)
        {
            ////debug.log("car is active");
            codeExecution.SetActive(true);
            one.SetActive(true);
            two.SetActive(true);
            three.SetActive(true);
        }
        else
        {
            codeExecution.SetActive(false);
        }
    }
}
