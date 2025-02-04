﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOneAnswerKey : MonoBehaviour
{
    /* Whether the answers are correct or not */
    public GameObject [] destinations = new GameObject[12];
    public static bool allSolved;
    // Start is called before the first frame update
    void Start()
    {
        allSolved = false;
        /* populate the answers array */

    }

    /* Turn solved to true iff all twelve things are in the right place */
    public void checkAnswers()
    {
        allSolved = true;
        foreach(GameObject destination in destinations)
        {
            if (!destination.GetComponent<correctPanelOn>().getSolved())
            {
                allSolved = false;
            }
        }
    }
}
