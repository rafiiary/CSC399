﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetGameOver : MonoBehaviour
{
    public GameObject GameOverCube;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Dreamcar01") && !FinishLine.game_over)
        {
            FinishLine.game_over = true;
        }
    }
}
