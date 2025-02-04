﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class change_terrain_increaseSize : MonoBehaviour
{
    public TextMeshProUGUI text_increase;
    public TextMeshProUGUI title;
    private bool entered_enumerate = false;
    private float originalFontSize;
    private bool doneIncrease = false;
    private bool doneFontIncrease = false;
    public int increaseUntil;
    public float timeGapsBetweenEachIncrease;
    private bool doneFirstEnumerate = false;
    private bool secondEnumerator = false;
    // Start is called before the first frame update
    void Start()
    {
        originalFontSize = text_increase.fontSize;
        //StartCoroutine(IncreaseFontSizeEnumeratorContinously());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.isActiveAndEnabled)
        {
            ////debug.log("this is active");
            StartCoroutine(IncreaseFontSizeEnumerator());
            if (doneFirstEnumerate)
            {
                FontSizeIncrease();
                if (!entered_enumerate)
                {
                    StartCoroutine(IncreaseFontSizeEnumeratorContinously());
                }
            }
        }

    }
    IEnumerator IncreaseFontSizeEnumerator()
    {
        yield return new WaitForSeconds((float)1.3);
        doneFirstEnumerate = true;
        ////debug.log("finished first font change");

    }
    IEnumerator IncreaseFontSizeEnumeratorContinously()
    {
        entered_enumerate = true;
        yield return new WaitForSeconds((float)timeGapsBetweenEachIncrease);
        resetFontSizeIncrease();
        entered_enumerate = false;

    }
    void FontSizeIncrease()
    {
        if (text_increase.fontSize == increaseUntil)
        {
            doneIncrease = true;
        }
        if (!doneIncrease)
        {
            ////debug.log("INCREASING");
            text_increase.fontSize += 1;
            title.fontSize += 1;
        }
        else if (doneIncrease)
        {
            if (text_increase.fontSize > originalFontSize)
            {
                ////debug.log("DECREASING");
                text_increase.fontSize -= 1;
                title.fontSize -= 1;
            }
        }
        if (text_increase.fontSize == originalFontSize & doneIncrease)
        {
            ////debug.log("doneFontIncrease is now true");
            doneFontIncrease = true;
        }
    }
    void resetFontSizeIncrease()
    {
        if (doneFontIncrease)
        {
            doneIncrease = false;
            doneFontIncrease = false;
        }
    }
}
