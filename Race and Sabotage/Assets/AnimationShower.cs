﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

public class AnimationShower : MonoBehaviour
{
    public Canvas puzzlecanvas;
    public void CameraSwitching()
    {
        puzzlecanvas.gameObject.SetActive(true);
        Destroy(gameObject);
    }
}
