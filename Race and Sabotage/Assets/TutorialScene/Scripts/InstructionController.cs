﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstructionController : MonoBehaviour
{
    public GameObject finishCanvas;
    public GameObject instructionCanvas;
    public GameObject car;
    public TextMeshProUGUI instructions;
    public TextMeshProUGUI intro;
    bool accelerate, brake, steer;
    private bool paused;
    Collider carCollider;
    private void Start()
    {
        accelerate = true;
        brake = true;
        steer = true;
        paused = false;
        carCollider = car.GetComponent<Collider>();

    }
    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        if (Input.GetKey("up") && accelerate)
        {
            accelerate = false;
            Debug.Log("Up arrow pressed");
            instructionCanvas.active = false;
            intro.text = "";
            instructions.text = "Press the Left and Right Arrow Keys to steer Left and Right.";
        }
        if (car.GetComponent<Rigidbody>().position.x > 700 && steer)
        {
            //Pause the moving car
            instructionCanvas.active = true;
            paused = true;
            if (Input.GetKey("left") || Input.GetKey("right"))
            {
                steer = false;
                instructionCanvas.active = false;
                paused = false;
                instructions.text = "Press the Down Arrow Key to brake. Make sure you control your speed. The faster you go, the more difficult to stop!";
            }
        }
        if (car.GetComponent<Rigidbody>().position.z > 350 && brake)
        {
            instructionCanvas.active = true;
            paused = true;
            if (Input.GetKey("down")){
                brake = false;
                instructionCanvas.active = false;
                paused = false;
                instructions.text = "Congratulations. You can now drive! Let's talk a little about changing your surrounding before a game.";
            }
        }
    }
    public void reachedEnd()
    {
        paused = true;
        instructionCanvas.active = true;
    }
}