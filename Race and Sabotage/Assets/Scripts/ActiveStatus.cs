﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveStatus : MonoBehaviour
{
    public GameObject canvas;
    public GameObject currentCanvas;
    public GameObject secondCanvas;
    public GameObject timer;
    private bool twocanvas = true;
    private bool timerbool = true;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        if (!currentCanvas.activeInHierarchy & !secondCanvas.activeInHierarchy & twocanvas)
        {
            Debug.Log("both canvases are set to false");
            Debug.Log(canvas.activeInHierarchy.ToString() + "before canvas status");
            canvas.SetActive(true);
            Debug.Log(canvas.activeInHierarchy.ToString() + "canvas status");
            twocanvas = false;
        }
        if (timer.activeInHierarchy & timerbool)
        {
            canvas.SetActive(false);
            timerbool = false;
        }
    }
}