﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDragDropForLoop3 : MonoBehaviour
{
    public Canvas puzzlecanvas;
    public Image wronganswer;
    public Canvas pausecanvas;
    Button button;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        wronganswer.gameObject.SetActive(false);
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(CheckAnswer);
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 0)
        {
            wronganswer.gameObject.SetActive(true);
            counter--;
        }
        else
        {
            wronganswer.gameObject.SetActive(false);
        }
    }

    public void CheckAnswer()
    {
        Debug.Log("first is " + NewSlot.first.ToString());
        Debug.Log("second is " + NewSlot.second.ToString());
        Debug.Log("third is " + NewSlot.third.ToString());
        Debug.Log("fourth is " + NewSlot.fourth.ToString());
        Debug.Log("fifth is " + NewSlot.fifth.ToString());
        if ((NewSlot.first && NewSlot.second && NewSlot.third && NewSlot.fourth && NewSlot.fifth)||RearrangementDragAndDrop.RearrangedCorrect)
        {
            Debug.Log("WENT HERE BOYSSSSS");
            puzzlecanvas.gameObject.SetActive(false);
            pausecanvas.gameObject.SetActive(true);
        }
        else
        {
            counter = 60;
        }
    }
}
